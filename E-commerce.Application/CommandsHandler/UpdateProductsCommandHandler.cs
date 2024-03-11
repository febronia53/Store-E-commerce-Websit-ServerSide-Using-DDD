using AutoMapper;
using E_commerce.Application.Commands;
using E_commerce.Infrastructure.Data;
using E_commerceWebsite.AggregateModels.IRepositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
namespace E_commerce.Application.CommandsHandler
{
    public class UpdateProductsCommandHandler : IRequestHandler<UpdateProductsCommand, Unit>
    {
        private readonly StoreDbContext _dbContext;
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public UpdateProductsCommandHandler(StoreDbContext dbContext, IProductRepository productRepository, IMapper mapper)
        {
            _dbContext = dbContext;
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateProductsCommand request, CancellationToken cancellationToken)
        {
            var existingProduct = await _productRepository.GetProductByName(request.UpdatedName);

            if (existingProduct != null && existingProduct.Id != request.ProductId)
            {
                throw new InvalidOperationException($"Product with the name '{request.UpdatedName}' already exists.");
            }

            var product = await _dbContext.products.FindAsync(request.ProductId);

            if (product != null)
            {
                _mapper.Map(request, product);

                // Retrieve ProductType and ProductBrand by name
                var updatedProductType = await _dbContext.productTypes.FirstOrDefaultAsync(pt => pt.ProductTypeName == request.UpdatedProductTypeName);
                var updatedProductBrand = await _dbContext.productBrands.FirstOrDefaultAsync(pb => pb.ProductBrandName == request.UpdatedProductBrandName);

                if (updatedProductType != null)
                {
                    product.ProductTypeId = updatedProductType.ProductTypeId;
                }

                if (updatedProductBrand != null)
                {
                    product.ProductBrandId = updatedProductBrand.ProductBrandId;
                }

                await _dbContext.SaveChangesAsync(cancellationToken);
            }

            return Unit.Value;
        }
    }
}