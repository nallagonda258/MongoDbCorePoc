using Microsoft.AspNetCore.Mvc;
using MongoDbService.Impl;
using MongoDbService.Models;

namespace MongoDbCorePoc.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        public readonly ICustomerService _customerService;
        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        public IActionResult GetCustomers()
        {
            var customers = _customerService.GetList();
            return Ok(customers);
        }

        [HttpGet("{id:length(24)}", Name ="GetCustomer")]
        public IActionResult GetCustomer([FromRoute]string id)
        {
            var customer = _customerService.Get(id);
            return Ok(customer);
        }

        [HttpPost]
        public IActionResult CreateCustomer([FromBody]Customer customer)
        {
            var result =_customerService.CreateCustomer(customer);
            return Ok(result);
        }

        [HttpPatch]
        public IActionResult UpdateCustomer([FromBody]Customer  customer)
        {
            var result = _customerService.UpdateCustomer(customer);
            return Ok(result);
        }
        
        [HttpDelete("{id:length(24)}")]
        public IActionResult DeleteCustomer([FromRoute]string id)
        {
            var result = _customerService.DeleteCustomer(id);
            return Ok(result);
        }

    }
}
