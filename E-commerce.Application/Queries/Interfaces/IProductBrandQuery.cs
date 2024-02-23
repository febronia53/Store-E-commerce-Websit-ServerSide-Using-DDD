using E_commerceWebsite.AggregateModels.ProductAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce.Application.Queries.Interfaces
{
    public interface IProductBrandQuery
    {
        public Task<IReadOnlyList<ProductBrand>> GetProductBrands();
        public Task<ProductBrand> GetProductBrandById(int id);
        public Task<ProductBrand> GetProductBrandByName(string name);
    }
}
