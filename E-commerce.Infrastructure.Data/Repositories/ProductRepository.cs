using E_commerceWebsite.AggregateModels.ProductAggregate;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce.Infrastructure.Data.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly StoreDbContext _dbContext;

        public ProductRepository(StoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Product> GetProductById(int ProductId)
        {
            return await _dbContext.products
                 .Include(p => p.ProductType)
                .Include(P => P.ProductBrand)
                .FirstOrDefaultAsync(p=>p.Id==ProductId);

        }

        public async Task<Product> GetProductByName(string productName)
        {
            return await _dbContext.products
                 .Include(p => p.ProductType)
                .Include(P => P.ProductBrand)
                .FirstOrDefaultAsync(p => p.Name == productName);

        }

        public async Task<IReadOnlyList<Product>> GetProducts()
        {
            return await _dbContext.products
                .Include(p=>p.ProductType)
                .Include(P=>P.ProductBrand)
                .ToListAsync();
        }
    }
}
