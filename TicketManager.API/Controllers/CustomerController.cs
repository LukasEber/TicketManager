using Microsoft.AspNetCore.Mvc;
using TicketManager.API.Contracts;
using TicketManager.API.Services;
using TicketManager.Domain.Models;

namespace TicketManager.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerservice)
        {
            _customerService = customerservice;
        }

        [HttpPost("post")]
        public IActionResult CreateCustomer(CreateCustomerRequest request)
        {
            try
            {
                Customer customer = new Customer()
                {
                    Name = request.Name,
                    ID = Guid.NewGuid(),
                    Credentials = request.Credentials,
                    DeveloperID = request.DeveloperID,
                    TicketCount = request.TicketCount,
                    Tickets = request.Tickets,
                    Applications = request.Applications
                };

                _customerService.CreateCustomer(customer);

                return CreatedAtAction(
                        actionName: nameof(GetCustomer),
                        routeValues: new { id = customer.ID },
                        value: customer
                    );
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }

        [HttpPut("put/{id:guid}")]
        public IActionResult UpdateCustomer(Guid id, Customer request)
        {
            try
            {
                Customer customer = new Customer()
                {
                    Name = request.Name,
                    ID = request.ID,
                    Credentials = request.Credentials,
                    DeveloperID = request.DeveloperID,
                    TicketCount = request.TicketCount,
                    Tickets = request.Tickets,
                    Applications = request.Applications
                };

                _customerService.UpdateCustomer(customer);

                return CreatedAtAction(
                    nameof(GetCustomer),
                    new { id },
                    customer);
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpGet("get/{id:guid}")]
        public IActionResult GetCustomer(Guid id)
        {
            try
            {
                Customer customer = _customerService.GetCustomer(id);
                return Ok(customer);
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        [HttpDelete("del/{id:guid}")]
        public IActionResult DeleteCustomer(Guid id)
        {
            try
            {
                _customerService.DeleteCustomer(id);
                return NoContent();
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
    }
}
