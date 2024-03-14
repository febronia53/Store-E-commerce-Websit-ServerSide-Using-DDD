using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace E_commerceWebsite.AggregateModels.ProductAggregate
{
    public class ProductType
    {
        [Key]
        public int ProductTypeId { get; set; }
        public string ProductTypeName { get; set; }
    //    [JsonIgnore]
        public virtual ICollection<Product> Products { get; set; }
    }
}