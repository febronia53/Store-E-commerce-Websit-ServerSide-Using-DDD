using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerceWebsite.AggregateModels.ProductAggregate
{
    public interface IProductTypeRepository
    {
        public Task<ProductType> GetProductTypeById(int id);
        public Task<IReadOnlyList<ProductType>> GetProductTypes();
        public Task<ProductType> GetProductTypeByName(string name);
    }
}
