using TicketManager.Domain.Models;

namespace TicketManager.API.Services
{
    public interface ITicketService
    {
        public void CreateTicket(Ticket ticket);

        public Ticket GetTicket(Guid id);

        public void DeleteTicket(Guid id);

        public void UpdateTicket(Ticket ticket);
    }
}
