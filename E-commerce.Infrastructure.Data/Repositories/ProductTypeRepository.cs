using E_commerceWebsite.AggregateModels.IRepositories;
using E_commerceWebsite.AggregateModels.ProductAggregate;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce.Infrastructure.Data.Repositories
{
    public class ProductTypeRepository:IProductTypeRepository
    {
        
         
        private readonly StoreDbContext _dbContext;
        public ProductTypeRepository(StoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<ProductType> GetProductTypeById(int id)
        {
            return await _dbContext.productTypes.FindAsync(id);
        }

        public Task<ProductType> GetProductTypeByName(string name)
        {
            return _dbContext.productTypes.FirstOrDefaultAsync(p=>p.ProductTypeName==name);
        }

        public async Task<IReadOnlyList<ProductType>> GetProductTypes()
        {
            return await _dbContext.productTypes.ToListAsync();
        }


        public async Task AddProductType(ProductType productType)
        {
            _dbContext.productTypes.Add(productType);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateProductType(ProductType productType)
        {
            _dbContext.Entry(productType).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteProductType(int id)
        {
            var type = await _dbContext.productTypes.FindAsync(id);
            if (type != null)
            {
                _dbContext.productTypes.Remove(type);
                await _dbContext.SaveChangesAsync();
            }
        }

    }
}
