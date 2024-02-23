using E_commerceWebsite.AggregateModels.ProductAggregate;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce.Infrastructure.Data
{
    public interface IStoreDbContext
    {
        DbSet<Product> products { get; set; }
        DbSet<ProductBrand> productBrands { get; set; }
        DbSet<ProductType> productTypes { get; set; }
    }
}
