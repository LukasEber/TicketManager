using TicketManager.Domain.Models;

namespace TicketManager.API.Contracts
{
    public record CreateCustomerRequest
    (
        string Name,
        Credentials Credentials,
        Developer Developer,
        int TicketCount,
        List<Ticket> Tickets,
        List<Application>? Applications
    );
}
