using Microsoft.AspNetCore.Mvc;
using TicketManager.API.Contracts;
using TicketManager.API.Services;
using TicketManager.Domain.Models;

namespace TicketManager.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TicketController : ControllerBase
    {
        private readonly ITicketService _ticketservice;
        public TicketController(ITicketService ticketservice)
        {
            _ticketservice = ticketservice;
        }

        [HttpPost("post")]
        public IActionResult CreateTicket(CreateTicketRequest request)
        {
            try
            {
                Ticket ticket = new Ticket()
                {
                    ID = Guid.NewGuid(),
                    CustomerID = request.CustomerID,
                    DeveloperID = request.DeveloperID,
                    Title = request.Title,
                    Description = request.Description,
                    Application = request.Application,
                    Priority = request.Priority,
                    Status = request.Status,
                    Attachments = request.Attachments,
                    Comment = request.Comment
                };

                _ticketservice.CreateTicket(ticket);

                return CreatedAtAction(
                     nameof(GetTicket),
                     new { ticket.ID },
                     ticket
                    );
            }
            catch (Exception ex)
            {
                return BadRequest();
            }

        }

        [HttpPut("put/{id:guid}")]
        public IActionResult UpdateTicket(Guid id, Ticket request)
        {
            try
            {
                Ticket ticket = new Ticket()
                {
                    ID = request.ID,
                    CustomerID = request.CustomerID,
                    DeveloperID = request.DeveloperID,
                    Title = request.Title,
                    Description = request.Description,
                    Application = request.Application,
                    Priority = request.Priority,
                    Status = request.Status,
                    Attachments = request.Attachments,
                    Comment = request.Comment
                };

                _ticketservice.UpdateTicket(ticket);

                return CreatedAtAction(
                    nameof(GetTicket),
                    new { id },
                    ticket);
            }
            catch (Exception ex)
            {

                return NotFound();
            }
        }

        [HttpGet("get/{id:guid}")]
        public IActionResult GetTicket(Guid id)
        {
            try
            {
                Ticket ticket = _ticketservice.GetTicket(id);
                return Ok(ticket);
            }
            catch (Exception ex)
            {
                return NotFound();
            }
        }

        [HttpDelete("del/{id:guid}")]
        public IActionResult DeleteTicket(Guid id)
        {
            try
            {
                _ticketservice.DeleteTicket(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound();
            }
        }
    }
}
