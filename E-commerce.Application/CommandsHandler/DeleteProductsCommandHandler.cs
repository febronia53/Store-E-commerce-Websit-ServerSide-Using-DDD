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
    public class DeleteProductsCommandHandler : IRequestHandler<DeleteProductsCommand, Unit>
    {
        private readonly StoreDbContext _dbContext;

        public DeleteProductsCommandHandler(StoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Unit> Handle(DeleteProductsCommand request, CancellationToken cancellationToken)
        {
            var product = await _dbContext.products.FindAsync(request.ProductId);

            if (product != null)
            {
                _dbContext.products.Remove(product);
                await _dbContext.SaveChangesAsync(cancellationToken);
            }

            // Indicate success by returning Unit.Value (equivalent to void)
            return Unit.Value;
        }
    }

}
