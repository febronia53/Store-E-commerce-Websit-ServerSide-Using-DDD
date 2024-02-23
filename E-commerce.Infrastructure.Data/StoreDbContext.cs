using E_commerce.Infrastructure.Data.EntityConfigration;
using E_commerceWebsite.AggregateModels.ProductAggregate;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce.Infrastructure.Data
{
    public class StoreDbContext : DbContext, IStoreDbContext
    {

        public StoreDbContext(DbContextOptions<StoreDbContext> options) : base(options)
        {

        }
        public const string DEFAULT_SCHEMA = "dbo";

        public DbSet<Product> products { get; set; }
        public DbSet<ProductBrand> productBrands { get; set; }
        public DbSet<ProductType> productTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new ProductBrandEntityConfiguration());
            modelBuilder.ApplyConfiguration(new ProductTypeEntityConfiguration());
            modelBuilder.ApplyConfiguration(new ProductEntityConfiguration());


            //modelBuilder.ApplyConfigurationsFromAssembly(typeof(ProductBrandEntityConfiguration).Assembly);
            //modelBuilder.ApplyConfigurationsFromAssembly(typeof(ProductTypeEntityConfiguration).Assembly);
            //modelBuilder.ApplyConfigurationsFromAssembly(typeof(ProductEntityConfiguration).Assembly);

            modelBuilder.HasDefaultSchema(DEFAULT_SCHEMA);
        

        //modelBuilder.Entity<ProductBrand>().HasData(

        //        new ProductBrand { ProductBrandId = 1, ProductBrandName = "Zara" },
        //        new ProductBrand { ProductBrandId = 2, ProductBrandName = "Gucci" },
        //        new ProductBrand { ProductBrandId = 3, ProductBrandName = "Nike" },
        //        new ProductBrand { ProductBrandId = 4, ProductBrandName = "H&M" },
        //        new ProductBrand { ProductBrandId = 5, ProductBrandName = "Forever21" },
        //        new ProductBrand { ProductBrandId = 6, ProductBrandName = "Adidas" },
        //        new ProductBrand { ProductBrandId = 7, ProductBrandName = "Chanel" }
        //    );


        //modelBuilder.Entity<ProductType>().HasData(
        //        new ProductType
        //        {
        //            ProductTypeId = 1,
        //            ProductTypeName = "Coats"
        //        },
        //        new ProductType
        //        {
        //            ProductTypeId = 2,
        //            ProductTypeName = "Hats"
        //        },
        //        new ProductType
        //        {
        //            ProductTypeId = 3,
        //            ProductTypeName = "Boots"
        //        },
        //        new ProductType
        //        {
        //            ProductTypeId = 4,
        //            ProductTypeName = "Gloves"
        //        }

        //    );



        // modelBuilder.Entity<Product>().HasData(

        //         new Product
        //         {
        //             Id = 1,
        //             Name = "Angular Speedster Board 2000",
        //             Description = "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.",
        //             Price = 200,
        //             PictureUrl = "images/products/sb-ang1.png",
        //             ProductTypeId = 1,
        //             ProductBrandId = 1
        //         },
        //         new Product
        //         {
        //             Id = 2,
        //             Name = "Green Angular Board 3000",
        //             Description = "Nunc viverra imperdiet enim. Fusce est. Vivamus a tellus.",
        //             Price = 150,
        //             PictureUrl = "images/products/sb-ang2.png",
        //             ProductTypeId = 1,
        //             ProductBrandId = 1
        //         },
        //        new Product
        //        {
        //            Id = 3,
        //            Name = "Core Board Speed Rush 3",
        //            Description = "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
        //            Price = 180,
        //            PictureUrl = "images/products/sb-core1.png",
        //            ProductTypeId = 1,
        //            ProductBrandId = 2
        //        }, new Product
        //        {
        //            Id = 4,
        //            Name = "Net Core Super Board",
        //            Description = "Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Proin pharetra nonummy pede. Mauris et orci.",
        //            Price = 300,
        //            PictureUrl = "images/products/sb-core2.png",
        //            ProductTypeId = 1,
        //            ProductBrandId = 2
        //        },
        //        new Product
        //        {
        //            Id = 5,
        //            Name = "React Board Super Whizzy Fast",
        //            Description = "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.",
        //            Price = 250,
        //            PictureUrl = "images/products/sb-react1.png",
        //            ProductTypeId = 1,
        //            ProductBrandId = 4

        //        }
        //);


    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
        }
    }
}