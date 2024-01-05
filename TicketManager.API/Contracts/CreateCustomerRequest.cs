using TicketManager.Domain.Models;

namespace TicketManager.API.Contracts
{
    public record CreateCustomerRequest
    (
        string Name,
        Credentials Credentials,
        Guid AssignedDeveloperID,
        ICollection<Ticket> Tickets,
        ICollection<string>? Applications
    );
}
