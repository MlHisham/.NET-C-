using ContosoCrafts.WebSite.Models;
using ContosoCrafts.WebSite.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContosoCrafts.WebSite.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        public JsonFileProductService ProductService { get; }
        public ProductsController(JsonFileProductService productService)
        {
            this.ProductService = productService;
        }
        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return ProductService.GetProducts();
        }
        [Route("rate")]
        [HttpGet]
        public ActionResult Get([FromQuery]string ProductID, [FromQuery] int Rating)
        {
            ProductService.AddRating(ProductID, Rating);
            return Ok();
        }
    }
}
