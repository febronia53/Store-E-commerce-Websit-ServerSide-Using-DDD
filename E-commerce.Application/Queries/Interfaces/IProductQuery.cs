using E_commerceWebsite.AggregateModels.ProductAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce.Application.Queries.Interfaces
{
    public interface IProductQuery
    {

        public Task<IReadOnlyList<Product>> GetProducts();
        public Task<Product> GetProductById(int id);
        public Task<Product> GetProductByName(string name);
        Task<IReadOnlyList<Product>> SearchProducts(string searchTerm);

    }
}
