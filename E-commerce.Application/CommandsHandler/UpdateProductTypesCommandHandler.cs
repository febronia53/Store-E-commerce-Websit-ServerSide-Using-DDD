using E_commerce.Application.Commands;
using E_commerce.Infrastructure.Data;
using E_commerceWebsite.AggregateModels.IRepositories;
using MediatR;

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
        var existingType = await _productTypeRepository.GetProductTypeById(request.ProductTypeId);

        if (existingType == null)
        {
            throw new InvalidOperationException($"Product type with ID '{request.ProductTypeId}' not found.");
        }

        existingType.ProductTypeName = request.UpdatedProductTypeName;

        await _dbContext.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
