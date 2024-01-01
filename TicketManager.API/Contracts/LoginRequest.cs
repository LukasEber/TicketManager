using TicketManager.Domain.Models;

namespace TicketManager.API.Contracts
{
    public record LoginRequest
    (
        Credentials Credentials
    );
}
