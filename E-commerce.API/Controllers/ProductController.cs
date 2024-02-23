using E_commerce.Application.Queries.Interfaces;
using E_commerceWebsite.AggregateModels.ProductAggregate;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace E_commerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IProductQuery _productQuery;

        public ProductController(IMediator mediator, IProductQuery productQuery)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _productQuery = productQuery ?? throw new ArgumentNullException(nameof(productQuery));
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            try
            {
                var products = await _productQuery.GetProducts();
                return Ok(products);
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

                return Ok(product);
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

                return Ok(product);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error from Product Controller: {ex.Message}");
            }
        }
    }
}
