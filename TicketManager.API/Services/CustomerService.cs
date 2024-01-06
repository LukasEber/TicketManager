using Microsoft.EntityFrameworkCore;
using TicketManager.API.Persistence;
using TicketManager.Domain.Models;

namespace TicketManager.API.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly TicketManagerDbContext _dbContext;
        private readonly ITicketService _ticketService;
        private readonly IServiceProvider _serviceProvider;
        public CustomerService(TicketManagerDbContext dbContext, ITicketService ticketService, IServiceProvider serviceProvider)
        {
            _dbContext = dbContext;
            _ticketService = ticketService;
            _serviceProvider = serviceProvider;
        }

        public string CreateCustomer(Customer customer)
        {
            ILoginService loginService = _serviceProvider.GetRequiredService<ILoginService>();
            var existingDev = _dbContext.Developers.FirstOrDefault(d => d.ID == customer.DeveloperID);
            if(existingDev != null)
            {
                try
                {
                    var userAlreadyExists = loginService.Login(customer.Credentials);
                    if(userAlreadyExists == null) // user does not exist
                    {
                        _dbContext.Add(customer);
                        _dbContext.SaveChanges();
                        return "Created";
                    }
                    return "User already exists";
                }
                catch (Exception)
                {
                    return "Exception thrown";
                }
            }
            return "No developer found";

        }

        public bool DeleteCustomer(Guid id)
        {
            var custToDelete = _dbContext.Customers.Find(id);
            if (custToDelete != null)
            {
                var allTickets = _dbContext.Tickets.Where(t => t.CustomerID == id).ToList();
                foreach (var ticket in allTickets)
                {
                    _ticketService.DeleteTicket(ticket.ID);
                }
                _dbContext.Remove(custToDelete);
                _dbContext.SaveChanges();

                return true;
            }
            return false;
        }

        public Customer GetCustomer(Guid id)
        {
            var cust = _dbContext.Customers.Find(id);
            var tickets = _dbContext.Tickets.Where(t => t.CustomerID == id).ToList();
            cust.Tickets = tickets;
            return cust;
        }

        public Customer UpdateCustomer(Customer customer)
        {
            var custToUpdate = _dbContext.Customers
                                            .Include(c => c.Credentials)
                                            .Include(c => c.Tickets)
                                            .FirstOrDefault(c => c.ID == customer.ID);
            if (custToUpdate != null)
            {
                _dbContext.Entry(custToUpdate).CurrentValues.SetValues(customer);
                custToUpdate.Credentials = customer.Credentials;

                foreach (var ticket in customer.Tickets)
                {
                    var existingTicket = custToUpdate.Tickets.FirstOrDefault(t => t.ID == ticket.ID);
                    if (existingTicket != null)
                    {
                        _dbContext.Entry(existingTicket).CurrentValues.SetValues(ticket);
                    }
                    else
                    {
                        // Add new ticket
                        custToUpdate.Tickets.Add(ticket);
                    }
                }
                _dbContext.SaveChanges();

                var updated = GetCustomer(customer.ID);
                return updated;
            }
            return null;
        }
    }
}
