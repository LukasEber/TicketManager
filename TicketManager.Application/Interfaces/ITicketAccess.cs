using TicketManager.Domain.Models;

namespace TicketManager.Application
{
    public interface ITicketAccess
    {
        Task<Ticket> GetTicket(Guid ticketId);

        Task<bool> DeleteTicketAsync(Guid ticketId);

        Task<bool> CreateTicketAsync(Guid ticketId, Ticket ticket);

        Task<Ticket> UpdateTicketAsync(Guid ticketId, Ticket ticket);
    }
}