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

        [HttpPost("post")]
        public IActionResult CreateDeveloper(CreateDeveloperRequest request)
        {
            try
            {
                Developer developer = new Developer()
                {

                    Name = request.Name,
                    ID = Guid.NewGuid(),
                    Credentials = request.Credentials,
                    Tickets = request.Tickets,
                    TicketCount = request.TicketCount,
                    Customers = request.Customers,
                    CustomerCount = request.CustomerCount,
                    Applications = request.Applications
                };

                _developerService.CreateDeveloper(developer);

                return CreatedAtAction(
                    actionName: nameof(GetDeveloper),
                    routeValues: new { id = developer.ID },
                    value: developer
                    );
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPut("put/{id:guid}")]
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
                    TicketCount = request.TicketCount,
                    Customers = request.Customers,
                    CustomerCount = request.CustomerCount,
                    Applications = request.Applications
                };

                _developerService.UpdateDeveloper(developer);

                return CreatedAtAction(
                    nameof(GetDeveloper),
                    new { id },
                    developer);
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        [HttpGet("get/{id:guid}")]
        public IActionResult GetDeveloper(Guid id)
        {
            try
            {
                Developer developer = _developerService.GetDeveloper(id);
                return Ok(developer);
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        [HttpDelete("del/{id:guid}")]
        public IActionResult DeleteDeveloper(Guid id)
        {
            try
            {
                _developerService.DeleteDeveloper(id);
                return NoContent();
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
    }
}
