using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using E_commerceWebsite.AggregateModels.ProductAggregate;

namespace E_commerceWebsite.AggregateModels.IRepositories
{
    public interface IProductTypeRepository
    {
        public Task<ProductType> GetProductTypeById(int id);
        public Task<IReadOnlyList<ProductType>> GetProductTypes();
        public Task<ProductType> GetProductTypeByName(string name);
        
          public Task AddProductType(ProductType productType);
        public Task UpdateProductType(ProductType productType);
        public Task DeleteProductType(int id);
         
    }
}
