using Microsoft.AspNetCore.Mvc;
using TicketManager.API.Contracts;
using TicketManager.API.Services;
using TicketManager.Domain.Models;

namespace TicketManager.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DeveloperController : ControllerBase
    {
        private readonly IDeveloperService _developerService;
        public DeveloperController(IDeveloperService developerservice)
        {
            _developerService = developerservice;
        }

        [HttpPost("create")]
        public IActionResult CreateDeveloper(CreateDeveloperRequest request)
        {
            try
            {
                Developer developer = new Developer()
                {

                    Name = request.Name,
                    ID = Guid.NewGuid(),
                    Credentials = request.Credentials,
                    Applications = request.Applications
                };

                var created = _developerService.CreateDeveloper(developer);

                switch (created)
                {
                    case "Created":
                        return CreatedAtAction(
                            actionName: nameof(GetDeveloper),
                            routeValues: new { id = developer.ID },
                            value: developer
                        );
                    case "User already exists":
                        return BadRequest(new { Message = "There is already a user with the same E-Mail." });

                    case "Exception thrown":
                        return BadRequest(new { Message = "Exception thrown while creating user." });

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
        public IActionResult UpdateDeveloper(Guid id, Developer request)
        {
            try
            {
                Developer developer = new Developer()
                {
                    Name = request.Name,
                    ID = request.ID,
                    Credentials = request.Credentials,
                    Tickets = request.Tickets,
                    AssignedCustomers = request.AssignedCustomers,
                    Applications = request.Applications
                };

                var updated = _developerService.UpdateDeveloper(developer);

                if (updated != null)
                {
                    return CreatedAtAction(
                            nameof(GetDeveloper),
                            new { id },
                            updated);
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
        public IActionResult GetDeveloper(Guid id)
        {
            try
            {
                Developer developer = _developerService.GetDeveloper(id);
                return developer != null ? Ok(developer) : NotFound();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpDelete("del/{id:guid}")]
        public IActionResult DeleteDeveloper(Guid id)
        {
            try
            {
                bool deleted = _developerService.DeleteDeveloper(id);
                return deleted ? NoContent() : NotFound();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
