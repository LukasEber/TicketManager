using TicketManager.Domain.Models;

namespace TicketManager.API.Services
{
    public interface ICustomerService
    {
        public void CreateCustomer(Customer customer);

        public Customer GetCustomer(Guid id);

        public void DeleteCustomer(Guid id);

        public Customer UpdateCustomer(Customer customer);
    }
}
