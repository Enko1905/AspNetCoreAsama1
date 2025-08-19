using Entities.DataTransferObject;
using Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repositories.EFCore;
using Services.Contratcs;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Product : ControllerBase
    {
        private readonly IServiceManager _manager;

        public Product(IServiceManager manager)
        {
            _manager = manager;
        }
        [HttpGet]

        public async Task<IActionResult> GetAllProduct()
        {
            var result = await _manager.ProductService.GetAllProductAsync(false);
            if (result is null)
            {
                return NotFound();
            }
            return Ok(result);
        }
        [HttpGet("{id:int}")]

        public async Task<IActionResult> GetOneProduct([FromRoute] int id)
        {
            var result = await _manager.ProductService.GetOneProductAsync(id,false);
            if (result is null)
            {
                return NotFound();
            }
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] ProductDtoForInsert productDtoForInsert)
        {
            if (productDtoForInsert is not null)
            {
                await _manager.ProductService.CreateOneProductAsync(productDtoForInsert);
                return StatusCode(201, productDtoForInsert);
            }
            return BadRequest();

        }
        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateProduct([FromRoute] int id, [FromBody] ProductDtoForUpdate productDtoForUpdate)
        {
            if (productDtoForUpdate is not null)
            {
                var result = await _manager.ProductService.GetOneProductAsync(id, false);
                if (result is not null) {
                    await _manager.ProductService.UpdateOneProductAsync(id, productDtoForUpdate, false);
                }
                return StatusCode(201, productDtoForUpdate);
            }
            return BadRequest();

        }
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteProduct([FromRoute] int id)
        {
            var result = await _manager.ProductService.GetOneProductAsync(id, false);
            if (result is not null)
            {
                await _manager.ProductService.DeleteOneProductAsync(id, true);
                return NoContent();
            }
            return BadRequest();

        }
    }
}
