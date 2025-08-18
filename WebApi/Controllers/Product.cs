using Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repositories;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Product : ControllerBase
    {
        private readonly RepositoryContext _context;

        public Product(RepositoryContext context)
        {
            _context = context;
        }
        [HttpGet]

        public IActionResult GetProduct()
        {
            var result = _context.products.ToList();
            if (result is null)
            {
               return NotFound();
            }
            return Ok(result);
        }
        [HttpPost]
        public IActionResult CreateProduct([FromBody]Product product) 
        {
            if (product is not null) 
            {
                return StatusCode(201, product);
            }
            return BadRequest();
            
        }
        
    }
}
