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

        public void CreateTicket(Ticket ticket)
        {
            _dbContext.Add(ticket);
            _dbContext.SaveChanges();
        }

        public void DeleteTicket(Guid id)
        {
            var ticketToDelete = _dbContext.Tickets.Find(id);
            if (ticketToDelete != null)
            {
                _dbContext.Tickets.Remove(ticketToDelete);
                _dbContext.SaveChanges();
            }
        }

        public Ticket GetTicket(Guid id)
        {
            return _dbContext.Tickets.Find(id);
        }

        public void UpdateTicket(Ticket ticket)
        {
            var ticketToUpdate = _dbContext.Tickets.Find(ticket.ID);
            if (ticketToUpdate != null)
            {
                _dbContext.Entry(ticketToUpdate).CurrentValues.SetValues(ticket);
                _dbContext.SaveChanges();
            }
        }
    }
}
