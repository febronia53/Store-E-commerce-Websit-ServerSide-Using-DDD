using AutoMapper;
using E_commerce.API.Dtos;
using E_commerceWebsite.AggregateModels.ProductAggregate;

namespace E_commerce.API.Helpers
{
    public class MappingProfiles:Profile
    {
        public MappingProfiles() {
            CreateMap<Product, ProductToReturnDto>()
                .ForMember(d=>d.ProductType,
                o=>o.MapFrom(s=>s.ProductType.ProductTypeName))
             
                
                .ForMember(d=>d.ProductBrand,
                o=>o.MapFrom(s=>s.ProductBrand.ProductBrandName))
                .ForMember(d=>d.PictureUrl,o=>o.MapFrom<ProductUrlResolver>());
            
        }
    }
}
