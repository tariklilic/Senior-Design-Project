using computershopAPI.Models.Models;

namespace computershopAPI.Dtos.CartDtos
{
    public class CartItemDto
    {
        public string UserId { get; set; } = string.Empty;
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
