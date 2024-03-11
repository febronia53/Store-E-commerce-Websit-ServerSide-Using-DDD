using E_commerce.Application.Commands;
using E_commerce.Infrastructure.Data;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce.Application.CommandsHandler
{
    public class DeleteProductBrandsCommandHandler : IRequestHandler<DeleteProductBrandsCommand, Unit>
    {
        private readonly StoreDbContext _dbContext;

        public DeleteProductBrandsCommandHandler(StoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Unit> Handle(DeleteProductBrandsCommand request, CancellationToken cancellationToken)
        {
            var productBrand = await _dbContext.productBrands.FindAsync(request.ProductBrandId);

            if (productBrand != null)
            {
                _dbContext.productBrands.Remove(productBrand);
                await _dbContext.SaveChangesAsync(cancellationToken);
            }

            // Indicate success by returning Unit.Value (equivalent to void)
            return Unit.Value;
        }
    }
}
