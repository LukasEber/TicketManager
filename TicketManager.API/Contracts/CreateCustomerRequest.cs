using TicketManager.Domain.Models;

namespace TicketManager.API.Contracts
{
    public record CreateCustomerRequest
    (
        string Name,
        Credentials Credentials,
        Guid DeveloperID,
        ICollection<string>? Applications
    );
}
