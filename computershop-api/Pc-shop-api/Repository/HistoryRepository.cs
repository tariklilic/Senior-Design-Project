using computershopAPI.Data;
using computershopAPI.Models.Models;
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

        public async Task<Product> getProductById(int productId)
        {
            return await _context.Products.Include(x => x.Images).Where(x => x.Id == productId).FirstOrDefaultAsync();
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

        public async Task UpdateProductQuantity(int productId, int quantity)
        {
            var product = await _context.Products
                .Where(x => x.Id == productId)
                .FirstOrDefaultAsync();

            if(product.Quantity - quantity >= 0)
            {
                product.Quantity -= quantity;
            } else
            {
                throw new Exception("Invalid quantity for " + product.Name);
            }

            await _context.SaveChangesAsync();
        } 
    }
}
