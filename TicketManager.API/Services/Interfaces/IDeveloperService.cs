using TicketManager.Domain.Models;

namespace TicketManager.API.Services
{
    public interface IDeveloperService
    {
        public void CreateDeveloper(Developer developer);

        public Developer GetDeveloper(Guid id);

        public void DeleteDeveloper(Guid id);

        public void UpdateDeveloper(Developer developer);

    }
}
