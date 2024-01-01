using TicketManager.Domain.Models;

namespace TicketManager.Application
{
    public class LoginAccess : ILoginAccess
    {
        public async Task<Guid> LoginAsync(Credentials credentials)
        {
            return Guid.NewGuid();
        }
    }
}
