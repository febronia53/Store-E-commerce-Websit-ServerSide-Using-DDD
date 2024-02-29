using E_commerce.API.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;

namespace E_commerce.Application.Services
{
    public class SortingService
    {
        public IEnumerable<ProductToReturnDto> Sort(IEnumerable<ProductToReturnDto> source, SortingOrder order, string sortBy)
        {
            switch (sortBy.ToLower())
            {
                case "name":
                    return order == SortingOrder.Ascending ? source.OrderBy(item => item.Name, StringComparer.OrdinalIgnoreCase) : source.OrderByDescending(item => item.Name, StringComparer.OrdinalIgnoreCase);
                case "price":
                    return order == SortingOrder.Ascending ? source.OrderBy(item => item.Price) : source.OrderByDescending(item => item.Price);
                default:
                    return source;
            }
        }


    }
}
