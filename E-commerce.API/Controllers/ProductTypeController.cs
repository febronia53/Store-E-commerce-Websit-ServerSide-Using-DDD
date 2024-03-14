using AutoMapper;
using E_commerce.Application.Commands;
using E_commerce.Application.Queries.Interfaces;
using E_commerceWebsite.AggregateModels.ProductAggregate;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_commerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductTypeController : ControllerBase
    {
        private readonly IProductTypeQuery _productTypeQuery;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public ProductTypeController(IProductTypeQuery productTypeQuery, IMediator mediator, IMapper mapper)
        {
            _productTypeQuery = productTypeQuery;
            _mediator = mediator;
            _mapper = mapper;
        }
      

        [HttpGet]
        public async Task<IActionResult> GetAllProductTypes()
        {
            try
            {
                var types = await _productTypeQuery.GetProductTypes();
                return Ok(types);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error from Product Type Controller: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductTypeById(int id)
        {
            try
            {
                var type = await _productTypeQuery.GetProductTypeById(id);

                if (type == null)
                {
                    return NotFound($"Product Type with ID: {id} not found.");
                }

                return Ok(type);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error from Product Type Controller: {ex.Message}");
            }
        }

        [HttpGet("ByName/{productTypeName}")]
        public async Task<IActionResult> GetProductTypeByName(string productTypeName)
        {
            try
            {
                var type = await _productTypeQuery.GetProductTypeByName(productTypeName);

                if (type == null)
                {
                    return NotFound($"Product Type with name: {productTypeName} not found.");
                }

                return Ok(type);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error from Product Type Controller: {ex.Message}");
            }


        }

        [HttpPost]
        public async Task<IActionResult> AddProductType([FromBody] AddProductTypesCommand productType)
        {
            try
            {
                await _mediator.Send(new AddProductTypesCommand { ProductTypeName = productType.ProductTypeName });
                return Ok("Type added successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error from Product Type Controller: {ex.Message}");
            }
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProductType(int id, [FromBody] UpdateProductTypesCommand updatedProductType)
        {
            try
            {
                if (_mediator == null)
                {
                    return StatusCode(500, "Internal server error: _mediator is null.");
                }


                await _mediator.Send(new UpdateProductTypesCommand { ProductTypeId = id, UpdatedProductTypeName = updatedProductType.UpdatedProductTypeName });
                return Ok("Type updated successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error from Product Type Controller: {ex.Message}");
            }
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductType(int id)
        {
            try
            {
                await _mediator.Send(new DeleteProductTypesCommand { ProductTypeId = id });
                return Ok("Type deleted successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error from Product Type Controller: {ex.Message}");
            }
        }
    }
}
