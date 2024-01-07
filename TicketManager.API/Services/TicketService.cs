using TicketManager.API.Persistence;
using TicketManager.Domain.Models;

namespace TicketManager.API.Services
{
    public class TicketService : ITicketService
    {
        private readonly TicketManagerDbContext _dbContext;
        public TicketService(TicketManagerDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public string CreateTicket(Ticket ticket)
        {
            var existingDev = _dbContext.Developers.FirstOrDefault(d => d.ID == ticket.DeveloperID);
            var existingCust = _dbContext.Customers.FirstOrDefault(c => c.ID == ticket.CustomerID);
            if((ticket.DeveloperID != null && existingDev != null) || (ticket.CustomerID != null && existingCust != null))
            {
                try
                {
                    _dbContext.Add(ticket);
                    _dbContext.SaveChanges();
                    return "Created";
                }

                catch (Exception)
                {
                    return "Exception thrown";
                }
            }
            return "No developer or customer found";

        }

        public bool DeleteTicket(Guid id)
        {
            var ticketToDelete = _dbContext.Tickets.Find(id);
            if (ticketToDelete != null)
            {
                _dbContext.Tickets.Remove(ticketToDelete);
                _dbContext.SaveChanges();
                return true;
            }
            return false;
        }

        public Ticket GetTicket(Guid id)
        {
            return _dbContext.Tickets.Find(id);
        }

        public Ticket UpdateTicket(Ticket ticket)
        {
            var ticketToUpdate = _dbContext.Tickets.Find(ticket.ID);
            if (ticketToUpdate != null)
            {
                _dbContext.Entry(ticketToUpdate).CurrentValues.SetValues(ticket);
                _dbContext.SaveChanges();

                var updated = GetTicket(ticket.ID);
                return updated;
            }
            return null;
        }
    }
}
