using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce.Application.Commands
{
    public class DeleteProductsCommand : IRequest<Unit>
    {
        public int ProductId { get; set; }
    }
}
