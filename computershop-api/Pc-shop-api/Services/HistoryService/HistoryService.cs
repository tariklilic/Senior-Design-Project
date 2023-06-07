using computershopAPI.Dtos.CartDtos;
using computershopAPI.Models;
using computershopAPI.Repository;

namespace computershopAPI.Services.HistoryService
{
    public class HistoryService : IHistoryService
    {
        private readonly ICartItemRepository _cartItemRepository;
        private readonly IHistoryRepository _historyRepository;

        public HistoryService(ICartItemRepository cartItemRepository, IHistoryRepository historyRepository)
        {
            _cartItemRepository = cartItemRepository;
            _historyRepository = historyRepository;
        }

        public async Task<HistoryPriceDto> GetHistory(string id)
        {
            var response = new HistoryPriceDto();
            var userProducts = await _historyRepository.GetUserHistory(id);

            List<PurchaseHistory> newUserProducts = new List<PurchaseHistory>();

            double total = 0f;

            for (int i = 0; i < userProducts.Count; i++)
            {
                total = total + (userProducts[i].Product.Price * userProducts[i].Quantity);

                newUserProducts.Add(userProducts[i]);
                
            }
            response.HistoryItems = newUserProducts;
            response.Total = total;

            return response;
        }

        public async Task<HistoryPriceDto> Purchase(string id)
        {
            var userProducts = await _cartItemRepository.GetUserProducts(id);


            for (int i = 0; i < userProducts.Count; i++)
            {
                var product = await _historyRepository.getProductById(userProducts[i].Product.Id);
                if (product.Quantity < userProducts[i].Quantity)
                {
                    throw new Exception("Invalid Quantity");
                }

                var checkExists = await _historyRepository.GetHistorySingle(userProducts[i].UserId, userProducts[i].ProductId);
                if (checkExists == null)
                {
                    var newHistory = new PurchaseHistory
                    {
                        User = userProducts[i].User,
                        UserId = userProducts[i].UserId,
                        Product = userProducts[i].Product,
                        ProductId = userProducts[i].ProductId,
                        Quantity = userProducts[i].Quantity,
                    };

                    await _historyRepository.AddToHistory(newHistory);
                }
                else
                {
                    await _historyRepository.UpdateHistoryQuantity(checkExists.Id, userProducts[i].Quantity);
                }

                await _historyRepository.UpdateProductQuantity(userProducts[i].Product.Id, userProducts[i].Quantity);

            }
            await _cartItemRepository.DeleteAllCartItemsByUserId(id);

            return await GetHistory(id);
        }


        private double CalculatePrice(List<PurchaseHistory> items)
        {
            double total = 0;
            foreach (var item in items)
            {
                total = total + (item.Product.Price * item.Quantity);
            }

            return total;
        }

    }
}
