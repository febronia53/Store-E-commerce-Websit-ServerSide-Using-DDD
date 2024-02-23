using E_commerce.Application.Queries.Interfaces;
using E_commerceWebsite.AggregateModels.ProductAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce.Application.Queries.Implementation
{
    public class ProductBrandQuery : IProductBrandQuery
    {
        private readonly IProductBrandRepository _repository;
        public ProductBrandQuery(IProductBrandRepository repository) {
        _repository = repository;
        }
        public async Task<ProductBrand> GetProductBrandById(int id)
        {
            return await _repository.GetProductBrandById(id);

        }

        public async Task<ProductBrand> GetProductBrandByName(string name)
        {
            return await _repository.GetProductBrandByName(name);
        }

        public async Task<IReadOnlyList<ProductBrand>> GetProductBrands()
        {
           return await _repository.GetProductBrands();
        }
    }
}
