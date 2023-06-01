namespace computershopAPI.Dtos.CartDtos
{
    public class CartItemPriceDto
    {
        public List<CartItem> CartItems { get; set; }
        public double Total { get; set; }
    }
}
