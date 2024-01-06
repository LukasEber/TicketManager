using TicketManager.API.Persistence;
using TicketManager.API.Services;
using TicketManager.Domain.Models;

namespace TicketManager.API.Services
{
    public class LoginService : ILoginService
    {
        private readonly TicketManagerDbContext _dbContext;
        public LoginService(TicketManagerDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public object Login(Credentials credentials)
        {
            var customer = _dbContext.Customers.SingleOrDefault(c => c.Credentials.MailAddress == credentials.MailAddress && c.Credentials.Password == credentials.Password);
            if (customer != null)
            {

                return customer;


            }
            var developer = _dbContext.Developers.SingleOrDefault(d => d.Credentials.MailAddress == credentials.MailAddress && d.Credentials.Password == credentials.Password);
            if (developer != null)
            {


                return developer;


            }
            return null;
        }
    }
}
