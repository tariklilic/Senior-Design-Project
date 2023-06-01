using computershopAPI.Data;
using computershopAPI.Services.Auth;
using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace computershopAPI.Repository 
{
    public class CartItemRepository : ICartItemRepository
    {
        private readonly DataContext context;

        public CartItemRepository(DataContext context)
        {
            this.context = context;
        }

        public async Task<List<CartItem>> GetUserProducts(string id)
        {
            var user = context.Users.Where(a=>a.Id.Equals(id));
            if (user == null)
            {
                throw new Exception("User does not exist");
            }
            var userProducts = await context.CartItems
                .Include(x=>x.Product)
                .Where(x => x.UserId.Equals(id))
                .ToListAsync();

            //if (!userProducts.Any())
            //{
            //    throw new Exception("User does not have items in cart");
            //}
            return userProducts;
        }

        public async Task<List<CartItem>> AddUserProduct(CartItem cartItem)
        {
            context.CartItems.Add(cartItem);
            await context.SaveChangesAsync();

            return await GetUserProducts(cartItem.UserId);
        }

        public async Task<List<CartItem>> RemoveUserProduct(CartItem cartItem)
        {
            context.CartItems.Remove(cartItem);
            await context.SaveChangesAsync();

            return await GetUserProducts(cartItem.UserId);
        }

        public async Task<CartItem> GetCartItem(int id)
        {
            var cartItem = await context.CartItems
                .Include(x => x.Product)
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();

            return cartItem;
        }

        public async Task<CartItem> UpdateProductQuantity(int id, int quantity)
        {
            var cartItem = await GetCartItem(id);

            cartItem.Quantity = quantity;
            this.context.SaveChanges();

            return await GetCartItem(id);
        }

        public async Task DeleteAllCartItemsByProductId(int productId)
        {
            var cartItems = await context.CartItems.Where(x => x.ProductId == productId).ToListAsync();

            for (int i = 0; i < cartItems.Count; i++)
            {
                await RemoveUserProduct(cartItems[i]);
            }
        }

        public async Task DeleteAllCartItemsByUserId(string id)
        {
            var cartItems = await context.CartItems.Where(x => x.UserId.Equals(id)).ToListAsync();

            for (int i = 0; i < cartItems.Count; i++)
            {
                await RemoveUserProduct(cartItems[i]);
            }
        }


        public async Task<List<CartItem>> GetAllCartItems()
        {
            return await context.CartItems.ToListAsync();
        }

        public DataContext GetCartItemContext()
        {
            return context;
        }
    }
}
