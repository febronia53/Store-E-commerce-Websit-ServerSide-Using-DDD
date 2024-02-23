using AutoMapper;
using E_commerce.API.Dtos;
using E_commerceWebsite.AggregateModels.ProductAggregate;

namespace E_commerce.API.Helpers
{
    public class ProductUrlResolver : IValueResolver<Product, ProductToReturnDto, string>
    {
        private readonly IConfiguration _configuration;

        public ProductUrlResolver(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string Resolve(Product source, ProductToReturnDto destination, string destMember, ResolutionContext context)
        {
            if (!string.IsNullOrEmpty(source.PictureUrl))
                return _configuration["APIURL"] + source.PictureUrl;

            return null;
        }
    }
}
