using computershopAPI.Models.Models;

namespace computershopAPI.Models
{
    public class Component
    {
        public int Id { get; set; }
        public string Name { get; set; } = String.Empty;
        public string Image { get; set; } = String.Empty;
        public ICollection<Product> Products { get; } = new List<Product>();
    }
}
