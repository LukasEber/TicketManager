using TicketManager.Domain.Models;

namespace TicketManager.API.Services
{
    public class TicketService : ITicketService
    {
        private readonly Dictionary<Guid, Ticket> _tickets = new Dictionary<Guid, Ticket>();

        public void CreateTicket(Ticket ticket)
        {
            _tickets.Add(ticket.ID, ticket);
        }

        public void DeleteTicket(Guid id)
        {
            _tickets.Remove(id);
        }

        public Ticket GetTicket(Guid id)
        {
            return _tickets[id];
        }

        public void UpdateTicket(Ticket ticket)
        {
            _tickets[ticket.ID] = ticket;
        }
    }
}
