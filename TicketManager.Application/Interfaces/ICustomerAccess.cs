using System.ComponentModel;
using System.Diagnostics;
using TicketManager.Domain.Models;

namespace TicketManager.Application
{
    public interface ICustomerAccess
    {
        Task<Customer> GetCustomer(Guid customerId);

        Task<bool> DeleteCustomerAsync(Guid customerId);

        Task<bool> CreateCustomerAsync(Guid customerId, Customer customer);

        Task<Customer> UpdateCustomerAsync(Guid customerId, Customer customer);

    }
}