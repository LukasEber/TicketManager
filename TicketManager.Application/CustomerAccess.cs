using System.Net.Http.Headers;
using TicketManager.Application;
using TicketManager.Domain.Models;

namespace TicketManager.Application
{
    public class CustomerAccess : ICustomerAccess
    {
        public async Task<bool> CreateCustomerAsync(Guid customerId, Customer customer)
        {
            return true;
        }

        public async Task<bool> DeleteCustomerAsync(Guid customerId)
        {
            return true;
        }

        public async Task<Customer> GetCustomer(Guid customerId)
        {
            return new Customer
            {
                Credentials = new Credentials { MailAddress = "testcustomer@outlook.de", Password = "jjfiojfdsjfdij" },
                Name = "Customer Test 1",
                ID = Guid.NewGuid(),
                Developer = new Developer(),
                TicketCount = 2,
                Tickets = new List<Ticket>
                {
                    new Ticket
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
                    },
                    new Ticket
                    {
                        Application = new Domain.Models.Application { Name = "Ticket Manager2" },
                        ID = Guid.NewGuid(),
                        DeveloperID = Guid.NewGuid(),
                        CustomerID = Guid.NewGuid(),
                        Title = "Test Ticket",
                        Description = "Lorem ipsum dolor sit amet. Thats the description of the second TestTicket",
                        Priority = Domain.Enums.Priority.Low,
                        Status = Domain.Enums.Status.Done,
                        Attachments = new List<string> { "attachment1.png" },
                        Comment = "Thats the second ticket comment"
                    }
                }
            };
        }
        public async Task<Customer> UpdateCustomerAsync(Guid customerId, Customer customer)
        {
            return new Customer
            {
                Credentials = new Credentials { MailAddress = "testcustomer@outlook.de", Password = "jjfiojfdsjfdij" },
                Name = "Customer Test 1",
                ID = Guid.NewGuid(),
                Developer = new Developer(),
                TicketCount = 2,
                Tickets = new List<Ticket>
                {
                    new Ticket
                    {
                        Application = new Domain.Models.Application { Name = " Updated Ticket Manager" },
                        ID = Guid.NewGuid(),
                        DeveloperID = Guid.NewGuid(),
                        CustomerID = Guid.NewGuid(),
                        Title = "Test Ticket",
                        Description = "Lorem ipsum dolor sit amet. Thats the updated description of the first TestTicket",
                        Priority = Domain.Enums.Priority.Low,
                        Status = Domain.Enums.Status.Done,
                        Attachments = new List<string> { "attachment1.png" },
                        Comment = "Thats the first ticket comment"
                    },
                    new Ticket
                    {
                        Application = new Domain.Models.Application { Name = "Ticket Manager2" },
                        ID = Guid.NewGuid(),
                        DeveloperID = Guid.NewGuid(),
                        CustomerID = Guid.NewGuid(),
                        Title = "Test Ticket",
                        Description = "Lorem ipsum dolor sit amet. Thats the updated description of the second TestTicket",
                        Priority = Domain.Enums.Priority.Low,
                        Status = Domain.Enums.Status.Done,
                        Attachments = new List<string> { "attachment1.png" },
                        Comment = "Thats the second ticket comment"
                    }
                }
            };
        }
    }
}

