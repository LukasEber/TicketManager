using TicketManager.Domain.Models;

namespace TicketManager.API.Services
{
    public class DeveloperService : IDeveloperService
    {
        private readonly Dictionary<Guid, Developer> _developers = new Dictionary<Guid, Developer>();

        public void CreateDeveloper(Developer developer)
        {
            _developers.Add(developer.ID, developer);
        }

        public void DeleteDeveloper(Guid id)
        {
            _developers.Remove(id);
        }

        public Developer GetDeveloper(Guid id)
        {
            return _developers[id];
        }

        public void UpdateDeveloper(Developer developer)
        {
            _developers[developer.ID] = developer;
        }
    }
}
