using System.Text.Json.Serialization;

namespace computershopAPI.Models.Models
{
    public class Product
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string ShortDesc { get; set; } = string.Empty;
    public string LongDesc { get; set; } = string.Empty;
    public int Quantity { get; set; }
    public string Manufacturer { get; set; } = string.Empty;
    public double Price { get; set; }
    public double Rating { get; set; }
    public string Cover { get; set; } = string.Empty;
        public List<ImageArray> Images { get; set; } = new List<ImageArray>();
    public int ComponentId { get; set; }
    [JsonIgnore]
    public List<CartItem> cartItems { get; set; }
    [JsonIgnore]
    public List<PurchaseHistory> purchaseHistories { get; set; }


    }
}
