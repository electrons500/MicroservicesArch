using Microsoft.AspNetCore.Mvc;
using ProductMicroservice.Models.Data.MicroserviceSQLDBContext;
using ProductMicroservice.Repository;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProductMicroservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private IProduct _product;
        public ProductsController(IProduct product)
        {
            _product = product;
        }

        // GET: api/<ProductsController>
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var products = await _product.GetProductsAsync();
            return products.Count == 0 ? NotFound() : Ok(products); 
        }

        // GET api/<ProductsController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            var product = await _product.GetProductByIdAsync(id);
            return product is null ? NotFound() : Ok(product);
        }

        // POST api/<ProductsController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Product product)
        {
            bool result = await _product.AddProductAsync(product);
            return result ? Ok("Product successfully added") : NotFound();
        }

        // PUT api/<ProductsController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] Product product)
        {
            bool result = await _product.UpdateProductAsync(id, product);
            return result ? Ok("Product successfully updated") : NotFound();
        }

        // DELETE api/<ProductsController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            bool result = await _product.DeleteProductAsync(id);
            return result ? Ok("Product successfully deleted") : NotFound();
        }
    }
}
