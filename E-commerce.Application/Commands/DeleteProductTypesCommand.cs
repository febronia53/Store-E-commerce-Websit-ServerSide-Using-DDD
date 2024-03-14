using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce.Application.Commands
{
    public class DeleteProductTypesCommand:IRequest<Unit>
    {
        public int ProductTypeId { get; set; }
    }
}
