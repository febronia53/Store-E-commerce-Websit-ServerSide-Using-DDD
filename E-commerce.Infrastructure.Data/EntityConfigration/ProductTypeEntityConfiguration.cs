using E_commerceWebsite.AggregateModels.ProductAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce.Infrastructure.Data.EntityConfigration
{
    public class ProductTypeEntityConfiguration : IEntityTypeConfiguration<ProductType>
    {
        public void Configure(EntityTypeBuilder<ProductType> builder)
        {
            builder.HasKey(p => p.ProductTypeId);
          //  builder.Property(p => p.ProductTypeId).UseHiLo("productTypes", StoreDbContext.DEFAULT_SCHEMA);
            builder.HasData(
                new ProductType
                {
                    ProductTypeId = 1,
                    ProductTypeName = "Coats"
                },
                new ProductType
                {
                    ProductTypeId = 2,
                    ProductTypeName = "Hats"
                },
                new ProductType
                {
                    ProductTypeId = 3,
                    ProductTypeName = "Boots"
                },
                new ProductType
                {
                    ProductTypeId = 4,
                    ProductTypeName = "Gloves"
                }

            );
        }
    }
}
