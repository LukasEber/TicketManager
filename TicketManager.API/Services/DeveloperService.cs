﻿using Microsoft.EntityFrameworkCore;
using System.Net.Sockets;
using TicketManager.API.Contracts;
using TicketManager.API.Persistence;
using TicketManager.Domain.Models;

namespace TicketManager.API.Services
{
    public class DeveloperService : IDeveloperService
    {
        private readonly TicketManagerDbContext _dbContext;
        private readonly ICustomerService _customerService;
        private readonly ITicketService _ticketService;
        public DeveloperService(TicketManagerDbContext dbContext, ICustomerService customerService, ITicketService ticketService)
        {
            _dbContext = dbContext;
            _customerService = customerService;
            _ticketService = ticketService;
        }

        public void CreateDeveloper(Developer developer)
        {
            _dbContext.Add(developer);
            _dbContext.SaveChanges();
        }

        public void DeleteDeveloper(Guid id)
        {
            var devToDelete = _dbContext.Developers.Find(id);
            if(devToDelete != null)
            {
                var allCustomers = _dbContext.Customers.Where(c => c.DeveloperID == id).ToList();
                var allTickets = _dbContext.Tickets.Where(t => t.DeveloperID == id).ToList();
                foreach(var ticket in allTickets)
                {
                    _ticketService.DeleteTicket(ticket.ID);
                }
                foreach (var customer in allCustomers)
                {
                    _customerService.DeleteCustomer(customer.ID);
                }
                _dbContext.Remove(devToDelete);
                _dbContext.SaveChanges();
            }
        }

        public Developer GetDeveloper(Guid id)
        {
            var dev = _dbContext.Developers.Find(id);
            var customers = _dbContext.Customers.Where(c => c.DeveloperID == id).ToList();
            var tickets = _dbContext.Tickets.Where(t => t.DeveloperID == id).ToList();
            dev.AssignedCustomers = customers;
            dev.Tickets = tickets;
            return dev;
        }

        public Developer UpdateDeveloper(Developer developer)
        {
            var devToUpdate = _dbContext.Developers
                                .Include(d => d.AssignedCustomers)
                                .Include(d => d.Tickets)
                                .Include(d => d.Credentials)
                                .FirstOrDefault(d => d.ID == developer.ID);

            if (devToUpdate != null)
            {
                _dbContext.Entry(devToUpdate).CurrentValues.SetValues(developer);

                devToUpdate.Credentials.MailAddress = developer.Credentials.MailAddress;
                devToUpdate.Credentials.Password = developer.Credentials.Password;

                devToUpdate.AssignedCustomers.Clear(); 
                foreach (var customer in developer.AssignedCustomers)
                {
                    devToUpdate.AssignedCustomers.Add(customer);
                }

                devToUpdate.Tickets.Clear(); 
                foreach (var ticket in developer.Tickets)
                {
                    devToUpdate.Tickets.Add(ticket);
                }

                _dbContext.SaveChanges();
                var updated = GetDeveloper(developer.ID);
                return updated;
            }
            return null;
        }
    }
}
