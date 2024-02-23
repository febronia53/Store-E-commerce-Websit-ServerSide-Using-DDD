using E_commerce.Application.Queries.Interfaces;
using E_commerceWebsite.AggregateModels.ProductAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce.Application.Queries.Implementation
{
    public class ProductTypeQuery : IProductTypeQuery
    {
        private readonly IProductTypeRepository _repository;
        public ProductTypeQuery(IProductTypeRepository repository)
        {
            _repository = repository;
        }
        public async Task<ProductType> GetProductTypeById(int id)
        {
            return await _repository.GetProductTypeById(id);
        }

        public async Task<ProductType> GetProductTypeByName(string name)
        {
            return await _repository.GetProductTypeByName(name);
        }

        public async Task<IReadOnlyList<ProductType>> GetProductTypes()
        {
            return await _repository.GetProductTypes();
        }
    }
}
