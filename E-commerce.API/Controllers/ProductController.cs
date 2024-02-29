//using AutoMapper;
//using E_commerce.API.Dtos;
//using E_commerce.Application.Queries.Interfaces;
//using E_commerce.Application.Services;
//using E_commerceWebsite.AggregateModels.ProductAggregate;
//using MediatR;
//using Microsoft.AspNetCore.Mvc;
//using System;
//using System.Collections.Generic;
//using System.Threading.Tasks;

//namespace E_commerce.API.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class ProductController : ControllerBase
//    {
//        private readonly IMediator _mediator;
//        private readonly IProductQuery _productQuery;
//        private readonly IMapper _mapper;
//        private readonly SortingService _sortingService;

//        public ProductController(IMediator mediator, IProductQuery productQuery, IMapper mapper, SortingService sortingService)
//        {
//            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
//            _productQuery = productQuery ?? throw new ArgumentNullException(nameof(productQuery));
//            _mapper = mapper;
//            _sortingService = sortingService;

//        }
//        [HttpGet]
//        public async Task<IActionResult> GetAllProducts([FromQuery] SortingOrder order = SortingOrder.Ascending, [FromQuery] string sortBy = "Name")
//        {
//            try
//            {

//                var products = await _productQuery.GetProducts();
//                var productDtos = _mapper.Map<IEnumerable<ProductToReturnDto>>(products);

//                var sortedProductDtos = _sortingService.Sort(productDtos, order, sortBy).ToList();

//                return Ok(sortedProductDtos);

//            }
//            catch (Exception ex)
//            {
//                return StatusCode(500, $"Internal server error from Product Controller: {ex.Message}");
//            }
//        }


//        [HttpGet("{id}")]
//        public async Task<IActionResult> GetProductById(int id)
//        {
//            try
//            {
//                var product = await _productQuery.GetProductById(id);

//                if (product == null)
//                {
//                    return NotFound($"Product with ID: {id} not found.");
//                }

//                var productDto = _mapper.Map<ProductToReturnDto>(product);
//                return Ok(productDto);
//            }
//            catch (Exception ex)
//            {
//                return StatusCode(500, $"Internal server error from Product Controller: {ex.Message}");
//            }
//        }

//        [HttpGet("ByName/{productName}")]
//        public async Task<IActionResult> GetProductByName(string productName)
//        {
//            try
//            {
//                var product = await _productQuery.GetProductByName(productName);

//                if (product == null)
//                {
//                    return NotFound($"Product with name: {productName} not found.");
//                }

//                var productDto = _mapper.Map<ProductToReturnDto>(product);
//                return Ok(productDto);
//            }
//            catch (Exception ex)
//            {
//                return StatusCode(500, $"Internal server error from Product Controller: {ex.Message}");
//            }
//        }
//    }
//
//
//}






using AutoMapper;
using E_commerce.API.Dtos;
using E_commerce.Application.Queries.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_commerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductQuery _productQuery;
        private readonly IMapper _mapper;

        public ProductController(IProductQuery productQuery, IMapper mapper)
        {
            _productQuery = productQuery ?? throw new ArgumentNullException(nameof(productQuery));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProducts([FromQuery] SortingOrder order = SortingOrder.Ascending, [FromQuery] string sortBy = "Name")
        {
            try
            {
                var products = await _productQuery.GetProducts();
                var productDtos = _mapper.Map<IEnumerable<ProductToReturnDto>>(products);

                switch (sortBy.ToLower())
                {
                    case "name":
                        productDtos = order == SortingOrder.Ascending ? productDtos.OrderBy(item => item.Name, StringComparer.OrdinalIgnoreCase) : productDtos.OrderByDescending(item => item.Name, StringComparer.OrdinalIgnoreCase);
                        break;
                    case "price":
                        productDtos = order == SortingOrder.Ascending ? productDtos.OrderBy(item => item.Price) : productDtos.OrderByDescending(item => item.Price);
                        break;
                    default:
                        // No sorting needed for other cases
                        break;
                }

                return Ok(productDtos.ToList());
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error from Product Controller: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(int id)
        {
            try
            {
                var product = await _productQuery.GetProductById(id);

                if (product == null)
                {
                    return NotFound($"Product with ID: {id} not found.");
                }

                var productDto = _mapper.Map<ProductToReturnDto>(product);
                return Ok(productDto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error from Product Controller: {ex.Message}");
            }
        }

        [HttpGet("ByName/{productName}")]
        public async Task<IActionResult> GetProductByName(string productName)
        {
            try
            {
                var product = await _productQuery.GetProductByName(productName);

                if (product == null)
                {
                    return NotFound($"Product with name: {productName} not found.");
                }

                var productDto = _mapper.Map<ProductToReturnDto>(product);
                return Ok(productDto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error from Product Controller: {ex.Message}");
            }
        }
    }
}

 