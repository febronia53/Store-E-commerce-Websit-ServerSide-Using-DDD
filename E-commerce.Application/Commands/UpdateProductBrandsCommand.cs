using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce.Application.Commands
{
    public class UpdateProductBrandsCommand : IRequest<Unit>
    {
        public int ProductBrandId { get; set; }
        public string UpdatedProductBrandName { get; set; }
    }
}
