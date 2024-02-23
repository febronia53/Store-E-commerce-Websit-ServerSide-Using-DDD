using E_commerce.Application.Queries.Interfaces;
using E_commerceWebsite.AggregateModels.ProductAggregate;
using MediatR;
using System.Collections.Generic;

namespace E_commerce.Application.Queries.Implementation
{
  
        public class ProductQuery : IProductQuery
        {
            private readonly IProductRepository _productRepository;

            public ProductQuery(IProductRepository productRepository)
            {
                _productRepository = productRepository;
            }
            public Task<Product> GetProductById(int id)
            {
                return _productRepository.GetProductById(id);
            }

            public Task<Product> GetProductByName(string name)
            {
                return _productRepository.GetProductByName(name);

        }

        public async Task<IReadOnlyList<Product>> GetProducts()
            {
                return await _productRepository.GetProducts();
            }
        }
    

}
