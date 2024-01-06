using Microsoft.AspNetCore.Mvc;
using TicketManager.API.Contracts;
using TicketManager.API.Persistence;
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

        [HttpPost("create")]
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

                bool created = _ticketservice.CreateTicket(ticket);
                if (created)
                {
                    return CreatedAtAction(
                             nameof(GetTicket),
                             new { ticket.ID },
                             ticket);
                }
                else
                {
                    return BadRequest(new {Message = "Error while creating Ticket"});
                }

            }
            catch (Exception)
            {
                return BadRequest();
            }

        }

        [HttpPut("update/{id:guid}")]
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

               var updated = _ticketservice.UpdateTicket(ticket);
                if(updated != null) {
                    return CreatedAtAction(
                            nameof(GetTicket),
                            new { id },
                            ticket);
                }
                else
                {
                    return NotFound();
                }

            }
            catch (Exception)
            {

                return BadRequest();
            }
        }

        [HttpGet("get/{id:guid}")]
        public IActionResult GetTicket(Guid id)
        {
            try
            {
                Ticket ticket = _ticketservice.GetTicket(id);
                return ticket != null ? Ok(ticket) : NotFound();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpDelete("del/{id:guid}")]
        public IActionResult DeleteTicket(Guid id)
        {
            try
            {
                bool deleted = _ticketservice.DeleteTicket(id);
                return deleted ? NoContent() : NotFound();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
