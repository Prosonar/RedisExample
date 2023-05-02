using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductApi.Models;
using ProductApi.Utilities.Cache;

namespace ProductApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ICacheService _cacheService;

        public ProductController(ICacheService cacheService)
        {
            _cacheService = cacheService;
        }

        [HttpPost]
        public IActionResult AddProduct(Product product)
        {
            _cacheService.SetValue("test", product);
            return Ok(product);
        }

        [HttpGet]
        public IActionResult GetProduct() 
        {
            return Ok(_cacheService.GetValue<Product>("test"));
        }
    }
}
