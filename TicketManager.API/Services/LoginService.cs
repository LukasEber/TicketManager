using TicketManager.API.Services.Interfaces;
using TicketManager.Domain.Models;

namespace TicketManager.API.Services
{
    public class LoginService : ILoginService
    {
        public bool Login(Credentials credentials)
        {
            //check Developer and customer db
            //generate JWT Token based on account type 
            //return Token and account if succeded or error if not
            return true;
        }
    }
}
