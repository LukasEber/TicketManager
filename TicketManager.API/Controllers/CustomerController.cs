﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TicketManager.API.Contracts;
using TicketManager.Domain.Models;
using TicketManager.API.Services;

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
                    ID = Guid.NewGuid(),
                    Credentials = request.Credentials,
                    DeveloperID = request.DeveloperID,
                    TicketCount = request.TicketCount,
                    Tickets = request.Tickets
                };

                _customerService.CreateCustomer(customer);

                return CreatedAtAction(
                        actionName: nameof(GetCustomer),
                        routeValues: new { id = customer.ID },
                        value: customer
                    );
            }
            catch(Exception ex)
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
                    ID = request.ID,
                    Credentials = request.Credentials,
                    DeveloperID = request.DeveloperID,
                    TicketCount = request.TicketCount,
                    Tickets = request.Tickets
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
            catch(Exception ex)
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
            catch(Exception ex)
            {
                return NotFound();
            }
        }
    }
}