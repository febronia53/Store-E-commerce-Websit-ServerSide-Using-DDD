using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce.Application.Commands
{
    public class AddProductTypesCommand:IRequest<Unit>
    {
        public string ProductTypeName { get; set; }

    }
}
