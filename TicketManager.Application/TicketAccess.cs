using TicketManager.Application;
using TicketManager.Domain.Models;

namespace TicketManager.Application
{
    public class TicketAccess : ITicketAccess
    {
        public async Task<bool> CreateTicketAsync(Guid ticketId, Ticket ticket)
        {
            return true;
        }

        public async Task<bool> DeleteTicketAsync(Guid ticketId)
        {
            return true;
        }

        public async Task<Ticket> GetTicket(Guid ticketId)
        {
            return new Ticket
            {
                Application = new Domain.Models.Application { Name = "Ticket Manager" },
                ID = Guid.NewGuid(),
                DeveloperID = Guid.NewGuid(),
                CustomerID = Guid.NewGuid(),
                Title = "Test Ticket",
                Description = "Lorem ipsum dolor sit amet. Thats the description of the first TestTicket",
                Priority = Domain.Enums.Priority.Low,
                Status = Domain.Enums.Status.Done,
                Attachments = new List<string> { "attachment1.png" },
                Comment = "Thats the first ticket comment"
            };
        }

        public async Task<Ticket> UpdateTicketAsync(Guid ticketId, Ticket ticket)
        {
            return new Ticket
            {
                Application = new Domain.Models.Application { Name = "Ticket Manager updated" },
                ID = Guid.NewGuid(),
                DeveloperID = Guid.NewGuid(),
                CustomerID = Guid.NewGuid(),
                Title = "Test Ticket",
                Description = "Lorem ipsum dolor sit amet. Thats the updated description of the first TestTicket",
                Priority = Domain.Enums.Priority.Low,
                Status = Domain.Enums.Status.Done,
                Attachments = new List<string> { "attachment1.png" },
                Comment = "Thats the first updated ticket comment"
            };
        }
    }
}
