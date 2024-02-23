using E_commerce.Application.Queries.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_commerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductTypeController : ControllerBase
    {
        private readonly IProductTypeQuery _productTypeQuery;

        public ProductTypeController(IProductTypeQuery productTypeQuery)
        {
            _productTypeQuery = productTypeQuery;
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
    }
}
