using TicketManager.Domain.Enums;
using TicketManager.Domain.Models;

namespace TicketManager.API.Contracts
{
    public record CreateTicketRequest
    (
        Guid AssignedCustomerID,
        Guid AssignedDeveloperID,
        string Title,
        string Description,
        string Application,
        Priority Priority,
        Status Status,
        ICollection<string> Attachments,
        string Comment
    );
}
