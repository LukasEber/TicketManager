using TicketManager.Domain.Models;

namespace TicketManager.Application
{
    public interface ILoginAccess
    {
        Task<Guid> LoginAsync(Credentials credentials);
    }
}