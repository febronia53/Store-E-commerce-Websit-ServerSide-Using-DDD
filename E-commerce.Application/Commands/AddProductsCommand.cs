using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace E_commerce.Application.Commands
{
    public class AddProductsCommand: IRequest<Unit>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string PictureUrl { get; set; }
        public string ProductTypeName { get; set; }
        public string ProductBrandName { get; set; }
    }

}
