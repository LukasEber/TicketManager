using TicketManager.Domain.Models;

namespace TicketManager.Application
{
    public interface IDeveloperAccess
    {
        Task<Developer> GetDeveloperAsync(Guid developerId);

        Task<bool> DeleteDeveloperAsync(Guid developerId);

        Task<bool> CreateDeveloperAsync(Guid developerId, Developer developer);

        Task<Developer> UpdateDeveloperAsync(Guid developerId, Developer developer);
    }
}