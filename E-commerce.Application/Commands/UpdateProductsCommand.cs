using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce.Application.Commands
{

    public class UpdateProductsCommand : IRequest<Unit>
    {
        public int ProductId { get; set; }
        public string UpdatedName { get; set; }
        public string UpdatedDescription { get; set; }
        public decimal UpdatedPrice { get; set; }
        public string UpdatedPictureUrl { get; set; }
        public string UpdatedProductTypeName { get; set; }
        public string UpdatedProductBrandName { get; set; }
    }
}
