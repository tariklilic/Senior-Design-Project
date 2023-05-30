using computershopAPI.Dtos.CartDtos;

namespace computershopAPI.Services.CartService
{
    public interface ICartService
    {
        Task<List<CartItem>> GetUserProducts(string id);
        Task<List<CartItem>> AddUserProduct(CartItemDto cartItem);
        Task<List<CartItem>> RemoveUserProduct(int id);
        Task<CartItem> UpdateUserProductQuantity(int id, int quantity);
        Task DeleteAllCartItemsByProductId(int productId);
    }
}
