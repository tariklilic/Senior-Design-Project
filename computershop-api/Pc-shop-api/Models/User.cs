using Microsoft.AspNetCore.Identity;

namespace computershopAPI.Models
{
    public class User : IdentityUser
    {
        public string? Email { get; set; }
        
    }
}
