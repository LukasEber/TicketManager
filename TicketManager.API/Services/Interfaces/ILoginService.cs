using TicketManager.Domain.Models;

namespace TicketManager.API.Services
{
    public interface ILoginService
    {
        public object Login(Credentials credentials);
    }
}
