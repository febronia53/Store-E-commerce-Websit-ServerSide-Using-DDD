using AutoMapper;
using E_commerce.Application.Commands;
using E_commerce.Infrastructure.Data;
using E_commerceWebsite.AggregateModels.IRepositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

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
        // Check if a product with the updated name already exists
        var existingProduct = await _productRepository.GetProductByName(request.UpdatedName);

        if (existingProduct != null && existingProduct.Id != request.ProductId)
        {
            // Handle the case where a product with the updated name already exists
            throw new InvalidOperationException($"Product with the name '{request.UpdatedName}' already exists.");
        }

        var product = await _dbContext.products.FindAsync(request.ProductId);

        if (product != null)
        {
            product.Name = request.UpdatedName;
            product.Description = request.UpdatedDescription;
            product.Price = request.UpdatedPrice;
            product.PictureUrl = request.UpdatedPictureUrl;

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

        // Indicate success by returning Unit.Value (equivalent to void)
        return Unit.Value;
    }
}
