using System.Collections.Generic;
using System.Threading.Tasks;
using E_commerceWebsite.AggregateModels.ProductAggregate;

namespace E_commerceWebsite.AggregateModels.IRepositories
{
    public interface IProductRepository
    {
        Task<Product> GetProductById(int id);
        Task<Product> GetProductByName(string productName);
        Task<IReadOnlyList<Product>> GetProducts();

        Task AddProduct(Product product);
        Task DeleteProduct(int productId);
        Task UpdateProduct(Product product);
    }
}
