using E_commerce.Application.Commands;
using E_commerce.Infrastructure.Data;
using E_commerceWebsite.AggregateModels.IRepositories;
using E_commerceWebsite.AggregateModels.ProductAggregate;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace E_commerce.Application.CommandsHandler
{
    public class AddProductCommandHandler : IRequestHandler<AddProductsCommand, Unit>
    {
        private readonly StoreDbContext _dbContext;
        private readonly IProductRepository _productRepository;

        public AddProductCommandHandler(StoreDbContext dbContext, IProductRepository productRepository)
        {
            _dbContext = dbContext;
            _productRepository = productRepository;
        }

        public async Task<Unit> Handle(AddProductsCommand request, CancellationToken cancellationToken)
        {
            // Check if a product with the same name already exists
            var existingProduct = await _productRepository.GetProductByName(request.Name);

            if (existingProduct != null)
            {
                // Handle the case where a product with the same name already exists
                throw new InvalidOperationException($"Product with the name '{request.Name}' already exists.");
            }

            // Retrieve ProductType and ProductBrand by name
            var productType = await _dbContext.productTypes.FirstOrDefaultAsync(pt => pt.ProductTypeName == request.ProductTypeName);
            var productBrand = await _dbContext.productBrands.FirstOrDefaultAsync(pb => pb.ProductBrandName == request.ProductBrandName);

            if (productType == null || productBrand == null)
            {
                // Handle the case where the specified ProductType or ProductBrand does not exist
                throw new InvalidOperationException("Invalid ProductType or ProductBrand specified.");
            }

            var product = new Product
            {
                Name = request.Name,
                Description = request.Description,
                Price = request.Price,
                PictureUrl = request.PictureUrl,
                ProductTypeId = productType.ProductTypeId,
                ProductBrandId = productBrand.ProductBrandId
            };

            _dbContext.products.Add(product);
            await _dbContext.SaveChangesAsync(cancellationToken);

            // Indicate success by returning Unit.Value (equivalent to void)
            return Unit.Value;
        }
    }
}
