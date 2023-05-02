using System.Text.Json.Serialization;

namespace ProductApi.Models
{
    public class Product
    {
        [JsonIgnore]
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}
