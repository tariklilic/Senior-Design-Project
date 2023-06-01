﻿using computershopAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace computershopAPI.Repository
{
    public class HistoryRepository : IHistoryRepository
    {
        private readonly DataContext _context;

        public HistoryRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<List<PurchaseHistory>> GetUserHistory(string id)
        {
            var user = _context.Users.Where(a => a.Id.Equals(id));
            if (user == null)
            {
                throw new Exception("User does not exist");
            }
            var userProducts = await _context.PurchaseHistory
                .Include(x => x.Product)
                .Where(x => x.UserId.Equals(id))
                .ToListAsync();

            //if (!userProducts.Any())
            //{
            //    throw new Exception("User does not have items in cart");
            //}
            return userProducts;
        }
        public async Task<PurchaseHistory> GetHistorySingle (string userid, int id)
        {
            var cartItem = await _context.PurchaseHistory
                .Include(x => x.Product)
                .Where(x => x.UserId.Equals(userid) && x.ProductId == id)
                .FirstOrDefaultAsync();

            return cartItem;
        }

        public async Task<List<PurchaseHistory>> AddToHistory(PurchaseHistory cartItem)
        {
            _context.PurchaseHistory.Add(cartItem);
            await _context.SaveChangesAsync();

            return await GetUserHistory(cartItem.UserId);
        }

        public async Task<PurchaseHistory> GetSingleProduct(int id)
        {
            var cartItem = await _context.PurchaseHistory
                .Include(x => x.Product)
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();

            return cartItem;
        }


        public async Task<PurchaseHistory> UpdateHistoryQuantity(int id, int quantity)
        {
            var cartItem = await GetSingleProduct(id);

            cartItem.Quantity = cartItem.Quantity + quantity;
            this._context.SaveChanges();

            return await GetSingleProduct(id);
        }

    }
}
