using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerceWebsite.AggregateModels.ProductAggregate
{
    public interface IProductRepository
    {
        public Task<Product> GetProductById(int id);
        public Task<Product> GetProductByName(string productName);
        public Task<IReadOnlyList<Product>> GetProducts();

    }
}
