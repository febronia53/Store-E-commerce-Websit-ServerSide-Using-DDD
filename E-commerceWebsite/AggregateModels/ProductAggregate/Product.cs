using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace E_commerceWebsite.AggregateModels.ProductAggregate
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string PictureUrl { get; set; }

        public virtual ProductType ProductType { get; set; }
        
        public int ProductTypeId { get; set; }

        public virtual ProductBrand ProductBrand { get; set; }
        public int ProductBrandId { get; set;}
    }
}
