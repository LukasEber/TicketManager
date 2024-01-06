using TicketManager.Domain.Models;

namespace TicketManager.API.Services
{
    public interface ITicketService
    {
        public bool CreateTicket(Ticket ticket);

        public Ticket GetTicket(Guid id);

        public bool DeleteTicket(Guid id);

        public Ticket UpdateTicket(Ticket ticket);
    }
}
