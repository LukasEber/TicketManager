using Microsoft.EntityFrameworkCore;
using TicketManager.API.Persistence;
using TicketManager.Domain.Models;

namespace TicketManager.API.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly TicketManagerDbContext _dbContext;
        private readonly ITicketService _ticketService;
        public CustomerService(TicketManagerDbContext dbContext, ITicketService ticketService)
        {
            _dbContext = dbContext;
            _ticketService = ticketService;
        }

        public void CreateCustomer(Customer customer)
        {
            var existingDev = _dbContext.Developers.FirstOrDefault(d => d.ID == customer.DeveloperID);
            if(existingDev != null)
            {
                _dbContext.Add(customer);
                _dbContext.SaveChanges();
            }

        }

        public void DeleteCustomer(Guid id)
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
            }
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
                                            .Include(c => c.Applications)
                                            .Include(c => c.Tickets)
                                            .FirstOrDefault(c => c.ID == customer.ID);
            if (custToUpdate != null)
            {
                _dbContext.Entry(custToUpdate).CurrentValues.SetValues(customer);
                custToUpdate.Credentials = customer.Credentials;

                custToUpdate.Applications.Clear();
                foreach(var app in customer.Applications)
                {
                    custToUpdate.Applications.Add(app);
                }

                custToUpdate.Tickets.Clear();
                foreach (var ticket in customer.Tickets)
                {
                    custToUpdate.Tickets.Add(ticket);
                }
                _dbContext.SaveChanges();

                var updated = GetCustomer(customer.ID);
                return updated;
            }
            return null;
        }
    }
}
