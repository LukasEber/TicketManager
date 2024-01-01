using TicketManager.Domain.Enums;
using TicketManager.Domain.Models;

namespace TicketManager.API.Contracts
{
    public record CreateTicketRequest
    (
        Guid CustomerID,
        Guid DeveloperID,
        string Title,
        string Description,
        Application Application,
        Priority Priority,
        Status Status,
        List<string> Attachments,
        string Comment
    );
}
