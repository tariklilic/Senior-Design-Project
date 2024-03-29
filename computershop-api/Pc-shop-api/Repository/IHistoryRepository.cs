﻿using computershopAPI.Models.Models;

namespace computershopAPI.Repository
{
    public interface IHistoryRepository
    {
        Task<PurchaseHistory> GetHistorySingle(string userid, int id);
        Task<List<PurchaseHistory>> AddToHistory(PurchaseHistory cartItem);
        Task<List<PurchaseHistory>> GetUserHistory(string userId);
        Task<PurchaseHistory> UpdateHistoryQuantity(int id, int quantity);
        Task UpdateProductQuantity(int productId, int quantity);
        Task<PurchaseHistory> GetSingleProduct(int id);
        Task<Product> getProductById(int productId);
    }
}
