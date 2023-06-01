using Microsoft.AspNetCore.Identity;

namespace computershopAPI.Models
{
    public class User : IdentityUser
    {
        public string? Email { get; set; }
        public List<CartItem> cartItems { get; set; }
        public List<PurchaseHistory> purchaseHistories { get; set; }

    }
}
