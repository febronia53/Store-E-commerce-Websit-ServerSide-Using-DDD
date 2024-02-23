using E_commerceWebsite.AggregateModels.ProductAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce.Application.Queries.Interfaces
{
    public interface IProductTypeQuery
    {
       
        public Task<IReadOnlyList<ProductType>> GetProductTypes();
        public Task<ProductType> GetProductTypeById(int id);
        public Task<ProductType> GetProductTypeByName(string name);
    }
}
