using computershopAPI.Dtos.CartDtos;
using computershopAPI.Services.ProductService;
using Microsoft.EntityFrameworkCore;
using computershopAPI.Models.Models;
using computershopAPI.Data;
using computershopAPI.Repository;
using computershopAPI.Services.Auth;

namespace computershopAPI.Services.CartService
{
    public class CartService : ICartService
    {
        private ICartItemRepository cartItemRepository;
        private IAuthService _authService;
        private IProductService productService;
        private readonly DataContext _context;
        //private IOrderService orderService;
        //private IOrderProductService orderProductService;
        public CartService(
            IAuthService authService,
            ICartItemRepository cartItemRepository,
            IProductService productService,
            DataContext context)
            //, IOrderService orderService, IOrderProductService orderProductService)
        {
            this.cartItemRepository = cartItemRepository;
            this._authService = authService;
            this.productService = productService;
            this._context = context;
            //this.orderService = orderService;
           // this.orderProductService = orderProductService;
        }

        public async Task<List<CartItem>> GetUserProducts(string id)
        {
            var userProducts = await cartItemRepository.GetUserProducts(id);

            List<CartItem> newUserProducts = new List<CartItem>();

            for (int i = 0; i < userProducts.Count; i++)
            {
                if (userProducts[i].Quantity > userProducts[i].Product.Quantity)
                {
                    await UpdateUserProductQuantity(userProducts[i].Id, userProducts[i].Product.Quantity);
                    userProducts[i].Quantity = userProducts[i].Product.Quantity;
                    newUserProducts.Add(userProducts[i]);
                }
                else
                {
                    newUserProducts.Add(userProducts[i]);
                }
            }
            return newUserProducts;
        }


        public async Task<List<CartItem>> AddUserProduct(CartItemDto cartItem)
        {
            var userProducts = await GetUserProducts(cartItem.UserId);
            for (int i = 0; i < userProducts.Count; i++)
            {
                if (userProducts[i].ProductId == cartItem.ProductId)
                {
                    var product = await this.productService.GetProductById(cartItem.ProductId);
                    if ((userProducts[i].Quantity + cartItem.Quantity) > product.Data.Quantity)
                    {
                        //update to product.quantity
                        await this.cartItemRepository.UpdateProductQuantity(userProducts[i].Id, product.Data.Quantity);
                        return await this.cartItemRepository.GetUserProducts(cartItem.UserId);
                    }
                    else
                    {
                        //update to userProduct[i] + cartItem.Quantity
                        await this.cartItemRepository.UpdateProductQuantity(userProducts[i].Id, (userProducts[i].Quantity + cartItem.Quantity));
                        return await this.cartItemRepository.GetUserProducts(cartItem.UserId);
                    }
                }
            }
            var newCartItem = new CartItem
            {
                User = await this._authService.GetUserById(cartItem.UserId),
                UserId = cartItem.UserId,
                Product = await this.productService.GetProductByIdModel(cartItem.ProductId),
                ProductId = cartItem.ProductId,
                Quantity = cartItem.Quantity,
            };


            return await cartItemRepository.AddUserProduct(newCartItem);
        }

        public async Task<List<CartItem>> RemoveUserProduct(int id)
        {
            var product = await this.cartItemRepository.GetCartItem(id);

            return await this.cartItemRepository.RemoveUserProduct(product);
        }

        public async Task<CartItem> UpdateUserProductQuantity(int id, int quantity)
        {
            var cartItem = await this.cartItemRepository.GetCartItem(id);
            var product = await this.productService.GetProductByIdModel(cartItem.ProductId);
            if (quantity <= product.Quantity && quantity > 0)
            {
                return await this.cartItemRepository.UpdateProductQuantity(id, quantity);
            }
            throw new Exception("Invalid quantity");

        }

        public async Task DeleteAllCartItemsByProductId(int productId)
        {
            await this.cartItemRepository.DeleteAllCartItemsByProductId(productId);
        }
    }
}
