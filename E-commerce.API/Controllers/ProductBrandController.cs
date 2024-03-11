using AutoMapper;
using E_commerce.API.Dtos;
using E_commerce.Application.Commands;
using E_commerce.Application.Queries.Interfaces;
using E_commerceWebsite.AggregateModels.IRepositories;
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
    public class ProductBrandController : ControllerBase
    {
        private readonly IProductBrandQuery _productBrandQuery;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public ProductBrandController(IProductBrandQuery productBrandQuery, IMediator mediator, IMapper mapper)
        {
            _productBrandQuery = productBrandQuery;
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProductBrands()
        {
            try
            {
                var brands = await _productBrandQuery.GetProductBrands();
                return Ok(brands);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error from Product Brand Controller: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductBrandById(int id)
        {
            try
            {
                var brand = await _productBrandQuery.GetProductBrandById(id);

                if (brand == null)
                {
                    return NotFound($"Brand with ID: {id} not found.");
                }

                return Ok(brand);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error from Product Brand Controller: {ex.Message}");
            }
        }

        [HttpGet("ByName/{productBrandName}")]
        public async Task<IActionResult> GetProductBrandByName(string productBrandName)
        {
            try
            {
                var brand = await _productBrandQuery.GetProductBrandByName(productBrandName);

                if (brand == null)
                {
                    return NotFound($"Brand with name: {productBrandName} not found.");
                }

                return Ok(brand);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error from Product Brand Controller: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddProductBrand([FromBody] AddProductBrandsCommand productBrand)
        {
            try
            {
                await _mediator.Send(new AddProductBrandsCommand { ProductBrandName = productBrand.ProductBrandName });
                return Ok("Brand added successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error from Product Brand Controller: {ex.Message}");
            }
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProductBrand(int id, [FromBody] UpdateProductBrandsCommand updatedProductBrand)
        {
            try
            {
                await _mediator.Send(new UpdateProductBrandsCommand { ProductBrandId = id, UpdatedProductBrandName = updatedProductBrand.UpdatedProductBrandName });
                return Ok("Brand updated successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error from Product Brand Controller: {ex.Message}");
            }
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductBrand(int id)
        {
            try
            {
                await _mediator.Send(new DeleteProductBrandsCommand { ProductBrandId = id });
                return Ok("Brand deleted successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error from Product Brand Controller: {ex.Message}");
            }
        }
    }
}
