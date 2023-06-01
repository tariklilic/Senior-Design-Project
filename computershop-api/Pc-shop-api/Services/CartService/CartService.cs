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


        public async Task<CartItemPriceDto> GetUserProducts(string id)
        {
            var response = new CartItemPriceDto();
            var userProducts = await cartItemRepository.GetUserProducts(id);

            List<CartItem> newUserProducts = new List<CartItem>();

            double total = 0f;

            for (int i = 0; i < userProducts.Count; i++)
            {
                total = total + (userProducts[i].Product.Price*userProducts[i].Quantity);
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
            response.CartItems = newUserProducts;
            response.Total = total;

            return response;
        }


        public async Task<CartItemPriceDto> AddUserProduct(CartItemDto cartItem)
        {
            var newUserProducts = await GetUserProducts(cartItem.UserId);
            var userProducts = newUserProducts.CartItems;

            for (int i = 0; i < userProducts.Count; i++)
            {
                if (userProducts[i].ProductId == cartItem.ProductId)
                {
                    var product = await this.productService.GetProductById(cartItem.ProductId);
                    if ((userProducts[i].Quantity + cartItem.Quantity) > product.Data.Quantity)
                    {
                        //update to product.quantity
                        await this.cartItemRepository.UpdateProductQuantity(userProducts[i].Id, product.Data.Quantity);
                        var userProductResponse1 = await this.cartItemRepository.GetUserProducts(cartItem.UserId);
                        var response1 = new CartItemPriceDto();
                        response1.CartItems = userProductResponse1;
                        response1.Total = CalculatePrice(userProductResponse1);
                        return response1;
                    }
                    else
                    {
                        //update to userProduct[i] + cartItem.Quantity
                        await this.cartItemRepository.UpdateProductQuantity(userProducts[i].Id, (userProducts[i].Quantity + cartItem.Quantity));
                        var userProductResponse2 = await this.cartItemRepository.GetUserProducts(cartItem.UserId); 
                        var response2 = new CartItemPriceDto();
                        response2.CartItems = userProductResponse2;
                        response2.Total = CalculatePrice(userProductResponse2);
                        return response2;
                    }
                }
            }
            var newCartItem = new CartItem
            {
                User = await this._authService.GetUserById(cartItem.UserId), // cartItem.User
                UserId = cartItem.UserId,
                Product = await this.productService.GetProductByIdModel(cartItem.ProductId),
                ProductId = cartItem.ProductId,
                Quantity = cartItem.Quantity,
            };


            var userProductResponse = await cartItemRepository.AddUserProduct(newCartItem);
            var response = new CartItemPriceDto();
            response.CartItems = userProductResponse;
            response.Total = CalculatePrice(userProductResponse);

            return response;
        }

        public async Task<CartItemPriceDto> RemoveUserProduct(int id)
        {
            var product = await this.cartItemRepository.GetCartItem(id);

            var userProductResponse= await this.cartItemRepository.RemoveUserProduct(product);
            var response = new CartItemPriceDto();
            response.CartItems = userProductResponse;
            response.Total = CalculatePrice(userProductResponse);

            return response;
        }

        public async Task<CartItemPriceDto> UpdateUserProductQuantity(int id, int quantity)
        {
            var cartItem = await this.cartItemRepository.GetCartItem(id);
            var product = await this.productService.GetProductByIdModel(cartItem.ProductId);
            if (quantity <= product.Quantity && quantity > 0)
            {
                await this.cartItemRepository.UpdateProductQuantity(id, quantity);
                return await GetUserProducts(cartItem.UserId);
            }
            throw new Exception("Invalid quantity");
        }

        public async Task DeleteAllCartItemsByProductId(int productId)
        {
            await this.cartItemRepository.DeleteAllCartItemsByProductId(productId);
        }

        public async Task DeleteAllCartItemsByUserId(string id)
        {
            await this.cartItemRepository.DeleteAllCartItemsByUserId(id);
        }

        private double CalculatePrice(List<CartItem> items)
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

