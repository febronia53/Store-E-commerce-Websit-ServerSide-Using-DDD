using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using E_commerceWebsite.AggregateModels.ProductAggregate;

namespace E_commerceWebsite.AggregateModels.IRepositories
{
    public interface IProductBrandRepository
    {


        public Task<ProductBrand> GetProductBrandById(int id);
        public Task<IReadOnlyList<ProductBrand>> GetProductBrands();
        public Task<ProductBrand> GetProductBrandByName(string name);

    }
}
