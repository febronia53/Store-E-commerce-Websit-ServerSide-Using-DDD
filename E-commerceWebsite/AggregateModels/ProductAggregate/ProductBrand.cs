using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace E_commerceWebsite.AggregateModels.ProductAggregate
{
    public class ProductBrand
    {
        [Key]
        public int ProductBrandId { get; set; }


        [Required(ErrorMessage = "ProductBrandName is required")]
        public string ProductBrandName { get; set; }
        
        [JsonIgnore]
        public ICollection<Product> Products { get; set; }
    }
}
