using E_commerceWebsite.AggregateModels.ProductAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace E_commerce.Infrastructure.Data.EntityConfigration
{
    public class ProductBrandEntityConfiguration : IEntityTypeConfiguration<ProductBrand>
    {
        public void Configure(EntityTypeBuilder<ProductBrand> builder)
        {
           // builder.Property(p => p.ProductBrandId).UseHiLo("productBrands", StoreDbContext.DEFAULT_SCHEMA);

           builder.HasKey(p => p.ProductBrandId);

            builder.HasData(

                    new ProductBrand { ProductBrandId = 1, ProductBrandName = "Zara" },
                    new ProductBrand { ProductBrandId = 2, ProductBrandName = "Gucci" },
                    new ProductBrand { ProductBrandId = 3, ProductBrandName = "Nike" },
                    new ProductBrand { ProductBrandId = 4, ProductBrandName = "H&M" },
                    new ProductBrand { ProductBrandId = 5, ProductBrandName = "Forever21" },
                    new ProductBrand { ProductBrandId = 6, ProductBrandName = "Adidas" },
                    new ProductBrand { ProductBrandId = 7, ProductBrandName = "Chanel" }
                );

        }
    }
}
