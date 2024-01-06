using TicketManager.Domain.Models;

namespace TicketManager.API.Services
{
    public interface ICustomerService
    {
        public string CreateCustomer(Customer customer);

        public Customer GetCustomer(Guid id);

        public bool DeleteCustomer(Guid id);

        public Customer UpdateCustomer(Customer customer);
    }
}
