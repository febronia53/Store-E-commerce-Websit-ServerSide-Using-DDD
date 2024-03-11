using E_commerce.Application.Commands;
using E_commerce.Infrastructure.Data;
using E_commerceWebsite.AggregateModels.IRepositories;
using E_commerceWebsite.AggregateModels.ProductAggregate;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce.Application.CommandsHandler
{
    public class AddProductBrandsCommandHandler : IRequestHandler<AddProductBrandsCommand, Unit>
    {
        private readonly StoreDbContext _dbContext;
        private readonly IProductBrandRepository _productRepository;

        public AddProductBrandsCommandHandler(StoreDbContext dbContext, IProductBrandRepository productRepository)
        {
            _dbContext = dbContext;
            _productRepository = productRepository;
        }

        public async Task<Unit> Handle(AddProductBrandsCommand request, CancellationToken cancellationToken)
        {
            // Check if a product brand with the same name already exists
            var existingProductBrand = await _productRepository.GetProductBrandByName(request.ProductBrandName);

            if (existingProductBrand != null)
            {
               
                throw new InvalidOperationException($"Product brand with the name '{request.ProductBrandName}' already exists.");
            }

            var productBrand = new ProductBrand
            {
                ProductBrandName = request.ProductBrandName
            };

            _dbContext.productBrands.Add(productBrand);
            await _dbContext.SaveChangesAsync(cancellationToken);

            // Indicate success by returning Unit.Value (equivalent to void)
            return Unit.Value;
        }
    }
}
