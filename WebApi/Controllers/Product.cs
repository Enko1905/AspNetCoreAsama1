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

        public async Task<IActionResult> GetProduct()
        {
            var result = await _manager.ProductService.GetAllProductAsync(false);
            if (result is null)
            {
               return NotFound();
            }
            return Ok(result);
        }
        [HttpPost]
        public IActionResult CreateProduct([FromBody]Products products) 
        {
            if (products is not null) 
            {
                return StatusCode(201, products);
            }
            return BadRequest();
            
        }
        
    }
}
