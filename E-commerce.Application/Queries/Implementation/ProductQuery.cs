using E_commerce.Application.Queries.Interfaces;
using E_commerceWebsite.AggregateModels.IRepositories;
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
        public async Task<IReadOnlyList<Product>> SearchProducts(string searchTerm)

        {
            if (string.IsNullOrWhiteSpace(searchTerm.ToLower()))
            {
                throw new ArgumentException("Search term cannot be empty or null.", nameof(searchTerm));
            }

            var matchingProducts = (await _productRepository.GetProducts())
                .Where(p => p.Name.Contains(searchTerm, StringComparison.OrdinalIgnoreCase))
                .ToList();

            return matchingProducts;
        }
    }
}



