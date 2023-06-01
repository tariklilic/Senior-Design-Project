using computershopAPI.Models.Models;

namespace computershopAPI.Models
{
    public class PurchaseHistory
    {
        public int Id { get; set; }
        public string UserId { get; set; } = string.Empty;
        public User User { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }
}
