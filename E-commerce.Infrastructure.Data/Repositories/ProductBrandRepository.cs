using E_commerceWebsite.AggregateModels.ProductAggregate;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce.Infrastructure.Data.Repositories
{
    public class ProductBrandRepository : IProductBrandRepository
    {
        
        private readonly StoreDbContext _dbContext;
        public ProductBrandRepository(StoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<ProductBrand> GetProductBrandById(int id)
        {
            return await _dbContext.productBrands.FindAsync(id);
        }

        public async Task<ProductBrand> GetProductBrandByName(string name)
        {
            return await _dbContext.productBrands.FirstOrDefaultAsync(p=>p.ProductBrandName==name);
        }

        public async Task<IReadOnlyList<ProductBrand>> GetProductBrands()
        {
            return await _dbContext.productBrands.ToListAsync();
        }
    }
}
