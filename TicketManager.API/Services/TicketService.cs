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

        public bool CreateTicket(Ticket ticket)
        {
            try
            {
                _dbContext.Add(ticket);
                _dbContext.SaveChanges();
                return true;
            }

            catch (Exception)
            {
                return false;
            }
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
