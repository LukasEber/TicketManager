using TicketManager.Domain.Models;

namespace TicketManager.API.Contracts
{
    public record CreateDeveloperRequest
    (
        string Name,
        Credentials Credentials,
        ICollection<string>? Applications
    );
}
