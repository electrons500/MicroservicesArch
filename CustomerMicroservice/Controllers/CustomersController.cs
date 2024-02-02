using CustomerMicroservice.Models.Data.MicroservicedbContext;
using CustomerMicroservice.Repository;
using Microsoft.AspNetCore.Mvc;


namespace CustomerMicroservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomer _customer;
        public CustomersController(ICustomer customer)
        {
            _customer = customer;
        }

        // GET: api/<CustomersController>
        [HttpGet]
        public async Task<ActionResult> Get() 
        {
            var model = await _customer.GetCustomersAsync();
            return model.Count == 0 ? NotFound() : Ok(model);
        }

        // GET api/<CustomersController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            var model = await _customer.GetCustomerByIdAsync(id);
            return model is null ? NotFound() : Ok(model);
        }

        // POST api/<CustomersController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Customer customer)
        {
            bool result = await _customer.AddCustomerAsync(customer);
            return result ? Ok("Customer successfully Added") : NotFound();
        }

        // PUT api/<CustomersController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] Customer customer)
        {
            bool result = await _customer.UpdateCustomerAsync(id,customer);
            return result ? Ok("Customer successfully updated") : NotFound();
        }

        // DELETE api/<CustomersController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            bool result = await _customer.DeleteCustomerAsync(id);
            return result ? Ok("Customer successfully deleted") : NotFound();
        }
    }
}
