using TicketManager.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using TicketManager.API.Contracts;
using TicketManager.API.Services;
using TicketManager.API.Services.Interfaces;
namespace TicketManager.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly ILoginService _loginservice;
        public LoginController(ILoginService loginservice)
        {
            _loginservice = loginservice;
        }
        [HttpPost()]
        public IActionResult Login(LoginRequest request)
        {
            try
            {
                Credentials credentials = new Credentials()
                {
                    MailAddress = request.Credentials.MailAddress,
                    Name = request.Credentials.Name,
                    Password = request.Credentials.Password
                };

                bool credentialsValid = _loginservice.Login(credentials);
                if (credentialsValid)
                {
                    return Ok();
                }
                else
                {
                    return BadRequest(new { message = "Invalid userdata" });
                }
            }
            catch(Exception ex)
            {
                return BadRequest();
            }
        }
    }
}
