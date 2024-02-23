using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerceWebsite.AggregateModels.ProductAggregate
{
    public interface IProductBrandRepository
    {
      

        public Task<ProductBrand> GetProductBrandById(int id);
        public Task<IReadOnlyList<ProductBrand>> GetProductBrands();
        public Task<ProductBrand> GetProductBrandByName(string name);

    }
}
