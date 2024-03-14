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
    public class AddProductTypesCommandHandler : IRequestHandler<AddProductTypesCommand, Unit>
    {
        private readonly StoreDbContext _dbContext;
        private readonly IProductTypeRepository _productRepository;

        public AddProductTypesCommandHandler(StoreDbContext dbContext, IProductTypeRepository productRepository)
        {
            _dbContext = dbContext;
            _productRepository = productRepository;
        }

        public async Task<Unit> Handle(AddProductTypesCommand request, CancellationToken cancellationToken)
        {
            // Check if a product brand with the same name already exists
            var existingProductType = await _productRepository.GetProductTypeByName(request.ProductTypeName);

            if (existingProductType != null)
            {

                throw new InvalidOperationException($"Product type with the name '{request.ProductTypeName}' already exists.");
            }

            var productType = new ProductType
            {
                ProductTypeName = request.ProductTypeName
            };

            _dbContext.productTypes.Add(productType);
            await _dbContext.SaveChangesAsync(cancellationToken);

            // Indicate success by returning Unit.Value (equivalent to void)
            return Unit.Value;
        }
    }
}
