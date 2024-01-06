using TicketManager.Domain.Models;

namespace TicketManager.API.Services
{
    public interface IDeveloperService
    {
        public string CreateDeveloper(Developer developer);

        public Developer GetDeveloper(Guid id);

        public bool DeleteDeveloper(Guid id);

        public Developer UpdateDeveloper(Developer developer);

    }
}
