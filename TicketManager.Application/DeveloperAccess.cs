using TicketManager.Application;
using TicketManager.Domain.Models;

namespace TicketManager.Application
{
    public class DeveloperAccess : IDeveloperAccess
    {
        public async Task<bool> CreateDeveloperAsync(Guid developerId, Developer developer)
        {
            return true;
        }

        public async Task<bool> DeleteDeveloperAsync(Guid developerId)
        {
            return true;
        }

        public async Task<Developer> GetDeveloperAsync(Guid developerId)
        {
            return new Developer
            {
                Credentials = new Credentials { MailAddress = "dev@outlook.de", Password = "dopfjdjfisjfpie" },
                Name = "Dev Test 1",
                ID = Guid.NewGuid(),
                TicketCount = 2,
                CustomerCount = 2
            };
        }

        public async Task<Developer> UpdateDeveloperAsync(Guid developerId, Developer developer)
        {
            throw new NotImplementedException();
        }
    }
}
