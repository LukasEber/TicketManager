using Microsoft.AspNetCore.Mvc;
using TicketManager.API.Contracts;
using TicketManager.API.Services;
using TicketManager.Domain.Models;
namespace TicketManager.API.Controllers
{
    [ApiController]
    [Route("auth")]
    public class LoginController : ControllerBase
    {
        private readonly ILoginService _loginService;
        public LoginController(ILoginService loginservice)
        {
            _loginService = loginservice;
        }
        [HttpPost("login")]
        public IActionResult Login(LoginRequest request)
        {
            try
            {
                Credentials credentials = new Credentials()
                {
                    MailAddress = request.Credentials.MailAddress,
                    Password = request.Credentials.Password
                };

                object user = _loginService.Login(credentials);
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
