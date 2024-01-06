using Microsoft.AspNetCore.Mvc;
using TicketManager.API.Contracts;
using TicketManager.API.Services;
using TicketManager.Domain.Models;
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
        [HttpPost("auth")]
        public IActionResult Login(LoginRequest request)
        {
            try
            {
                Credentials credentials = new Credentials()
                {
                    MailAddress = request.Credentials.MailAddress,
                    Password = request.Credentials.Password
                };

                object user = _loginservice.Login(credentials);
                if (user != null)
                {
                    return Ok(user);
                }
                else
                {
                    return Unauthorized(new { message = "Invalid userdata" });
                }
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
