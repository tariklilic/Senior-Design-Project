using computershopAPI.Data;

namespace computershopAPI.Repository
{
    public interface ICartItemRepository
    {
        Task<List<CartItem>> GetUserProducts(string id);
        Task<List<CartItem>> AddUserProduct(CartItem cartItem);
        Task<List<CartItem>> RemoveUserProduct(CartItem cartItem);
        Task<CartItem> GetCartItem(int id);
        Task<CartItem> UpdateProductQuantity(int id, int quantity);
        Task DeleteAllCartItemsByProductId(int productId);
        Task<List<CartItem>> GetAllCartItems();
        DataContext GetCartItemContext();
    }
}
