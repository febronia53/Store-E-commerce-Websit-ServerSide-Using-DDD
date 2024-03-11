using AutoMapper;
using E_commerce.Application.Commands;
using E_commerce.Infrastructure.Data;
using E_commerceWebsite.AggregateModels.IRepositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
namespace E_commerce.Application.CommandsHandler
{
    public class UpdateProductTypesCommandHandler : IRequestHandler<UpdateProductTypesCommand, Unit>
    {
        private readonly StoreDbContext _dbContext;
        private readonly IProductTypeRepository _productTypeRepository;

        public UpdateProductTypesCommandHandler(StoreDbContext dbContext, IProductTypeRepository productTypeRepository)
        {
            _dbContext = dbContext;
            _productTypeRepository = productTypeRepository;
        }

        public async Task<Unit> Handle(UpdateProductTypesCommand request, CancellationToken cancellationToken)
        {
            // Check if the product type with the updated name already exists
            var existingType = await _productTypeRepository.GetProductTypeByName(request.UpdatedProductTypeName);

            if (existingType != null && existingType.ProductTypeId != request.ProductTypeId)
            {
                throw new InvalidOperationException($"Product Type with the name '{request.UpdatedProductTypeName}' already exists.");
            }

            // Retrieve the product type from the database using the ProductTypeId
            var type = await _dbContext.productTypes.FindAsync(request.ProductTypeId);

            // Ensure that the retrieved type is not null before updating
            if (type != null)
            {
                // Optionally, check if existingType is detached and attach it to the context
                if (_dbContext.Entry(type).State == EntityState.Detached)
                {
                    _dbContext.Attach(type);
                }

                // Update the ProductTypeName and save changes
                type.ProductTypeName = request.UpdatedProductTypeName;
                await _dbContext.SaveChangesAsync(cancellationToken);
            }

            // Indicate success by returning Unit.Value (equivalent to void)
            return Unit.Value;
        }
    }

}