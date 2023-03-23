using ContosoCrafts.WebSite.Models;
using ContosoCrafts.WebSite.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ContosoCrafts.WebSite.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private JsonFileProductService _productService;
        public ProductsController(JsonFileProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public IEnumerable<Product> Get()
        {   
            return _productService.GetProducts(); 
        }

        [Route("Ratings")]
        [HttpGet]
        public IActionResult GetRatings([FromQuery] string productId, [FromQuery] int rating)
        {
            _productService.AddRating(productId, rating);
            return Ok();
        }       
    }
}
