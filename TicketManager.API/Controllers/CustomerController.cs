using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
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

        [HttpPost("create")]
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
                    Tickets = request.Tickets,
                    Applications = request.Applications
                };

                var created = _customerService.CreateCustomer(customer);

                switch (created)
                {
                    case "Created":
                        return CreatedAtAction(
                            actionName: nameof(GetCustomer),
                            routeValues: new { id = customer.ID },
                            value: customer
                        );
                    case "User already exists":
                        return BadRequest(new { Message = "There is already a user with the same E-Mail." });

                    case "Exception thrown":
                        return BadRequest(new { Message = "Exception thrown while creating user." });

                    case "No developer found":
                        return BadRequest(new { Message = "There is no developer with the given ID" });

                    default:
                        return BadRequest();
                }
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }

        [HttpPut("update/{id:guid}")]
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
                    Tickets = request.Tickets,
                    Applications = request.Applications
                };

                var updated = _customerService.UpdateCustomer(customer);

                if (updated != null)
                {

                    return CreatedAtAction(
                        nameof(GetCustomer),
                        new { id },
                        customer);
                }
                else
                {
                    return NotFound();
                }

            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpGet("get/{id:guid}")]
        public IActionResult GetCustomer(Guid id)
        {
            try
            {
                Customer customer = _customerService.GetCustomer(id);
                return customer != null ? Ok(customer) : NotFound();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpDelete("del/{id:guid}")]
        public IActionResult DeleteCustomer(Guid id)
        {
            try
            {
                bool deleted = _customerService.DeleteCustomer(id);
                return deleted ? NoContent() : NotFound();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
