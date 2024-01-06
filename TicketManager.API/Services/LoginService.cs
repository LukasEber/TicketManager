using TicketManager.API.Persistence;
using TicketManager.API.Services;
using TicketManager.Domain.Models;

namespace TicketManager.API.Services
{
    public class LoginService : ILoginService
    {
        private readonly TicketManagerDbContext _dbContext;
        private readonly ICustomerService _customerService;
        private readonly IDeveloperService _developerService;
        public LoginService(TicketManagerDbContext dbContext, ICustomerService customerService, IDeveloperService developerService)
        {
            _dbContext = dbContext;
            _customerService = customerService;
            _developerService = developerService;
        }
        public object Login(Credentials credentials)
        {
            var customer = _dbContext.Customers.SingleOrDefault(c => c.Credentials.MailAddress == credentials.MailAddress);
            if (customer != null && customer.Credentials.Password == credentials.Password)
            {
                return _customerService.GetCustomer(customer.ID);
            }
            var developer = _dbContext.Developers.SingleOrDefault(d => d.Credentials.MailAddress == credentials.MailAddress);
            if (developer != null && developer.Credentials.Password == credentials.Password)
            {
                return _developerService.GetDeveloper(developer.ID);
            }
            return null;
        }
    }
}
