using TicketManager.Domain.Models;

namespace TicketManager.API.Services.Interfaces
{
    public interface ILoginService
    {
        public bool Login(Credentials credentials);
    }
}
