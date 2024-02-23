using E_commerceWebsite.AggregateModels.ProductAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce.Infrastructure.Data.EntityConfigration
{
    public class ProductEntityConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(p => p.Id);
           // builder.Property(p => p.Id).UseHiLo("products", StoreDbContext.DEFAULT_SCHEMA);

            builder.Property(p => p.Name).IsRequired().HasMaxLength(100);
            builder.Property(p => p.Description).IsRequired();
            builder.Property(p => p.Price).IsRequired().HasColumnType("decimal");
            builder.Property(p => p.PictureUrl).IsRequired();

            builder.HasOne(p => p.ProductBrand)
                .WithMany(pb => pb.Products)
                .HasForeignKey(p => p.ProductBrandId);

            builder.HasOne(p => p.ProductType)
                .WithMany(pt => pt.Products)
                .HasForeignKey(p => p.ProductTypeId);


            builder.HasData(

                    new Product
                    {
                        Id = 1,
                        Name = "Angular Speedster Board 2000",
                        Description = "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.",
                        Price = 200,
                        PictureUrl = "images/products/sb-ang1.png",
                        ProductTypeId = 1,
                        ProductBrandId = 1
                    },
                    new Product
                    {
                        Id = 2,
                        Name = "Green Angular Board 3000",
                        Description = "Nunc viverra imperdiet enim. Fusce est. Vivamus a tellus.",
                        Price = 150,
                        PictureUrl = "images/products/sb-ang2.png",
                        ProductTypeId = 1,
                        ProductBrandId = 1
                    },
                   new Product
                   {
                       Id = 3,
                       Name = "Core Board Speed Rush 3",
                       Description = "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                       Price = 180,
                       PictureUrl = "images/products/sb-core1.png",
                       ProductTypeId = 1,
                       ProductBrandId = 2
                   }, new Product
                   {
                       Id = 4,
                       Name = "Net Core Super Board",
                       Description = "Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Proin pharetra nonummy pede. Mauris et orci.",
                       Price = 300,
                       PictureUrl = "images/products/sb-core2.png",
                       ProductTypeId = 1,
                       ProductBrandId = 2
                   },
                   new Product
                   {
                       Id = 5,
                       Name = "React Board Super Whizzy Fast",
                       Description = "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.",
                       Price = 250,
                       PictureUrl = "images/products/sb-react1.png",
                       ProductTypeId = 1,
                       ProductBrandId = 4

                   }
           );
        }
    }

}
