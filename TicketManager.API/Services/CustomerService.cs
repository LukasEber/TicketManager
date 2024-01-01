using TicketManager.Domain.Models;

namespace TicketManager.API.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly Dictionary<Guid, Customer> _customers = new Dictionary<Guid, Customer>();

        public void CreateCustomer(Customer customer)
        {
            _customers.Add(customer.ID, customer);
        }

        public void DeleteCustomer(Guid id)
        {
            _customers.Remove(id);
        }

        public Customer GetCustomer(Guid id)
        {
            return _customers[id];
        }

        public void UpdateCustomer(Customer customer)
        {
            _customers[customer.ID] = customer;
        }
    }
}
