using TicketManager.Domain.Models;

namespace TicketManager.API.Contracts
{
    public record CreateDeveloperRequest
    (
        Credentials Credentials,
        List<Ticket>? Tickets,
        int TicketCount,
        List<Customer>? Customers,
        int CustomerCount,
        List<Application>? Applications 
    );
}
