using computershopAPI.Dtos.CartDtos;

namespace computershopAPI.Services.CartService
{
    public interface ICartService
    {
        Task<CartItemPriceDto> GetUserProducts(string id);
        Task<CartItemPriceDto> AddUserProduct(CartItemDto cartItem);
        Task<CartItemPriceDto> RemoveUserProduct(int id);
        Task<CartItemPriceDto> UpdateUserProductQuantity(int id, int quantity);
        Task DeleteAllCartItemsByProductId(int productId);
    }
}
