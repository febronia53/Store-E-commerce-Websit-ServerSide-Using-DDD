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
    public class DeleteProductTypesCommandHandler : IRequestHandler<DeleteProductTypesCommand, Unit>
    {
        private readonly StoreDbContext _dbContext;

        public DeleteProductTypesCommandHandler(StoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Unit> Handle(DeleteProductTypesCommand request, CancellationToken cancellationToken)
        {
            var productType = await _dbContext.productTypes.FindAsync(request.ProductTypeId);

            if (productType != null)
            {
                _dbContext.productTypes.Remove(productType);
                await _dbContext.SaveChangesAsync(cancellationToken);
            }

            // Indicate success by returning Unit.Value (equivalent to void)
            return Unit.Value;
        }
    }

}
