using E_commerce.Application.Queries.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_commerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductBrandController : ControllerBase
    {
        private readonly IProductBrandQuery _productBrandQuery;

        public ProductBrandController(IProductBrandQuery productBrandQuery)
        {
            _productBrandQuery = productBrandQuery;
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
         

    }
}
