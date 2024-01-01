using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace TicketManager.Domain.Models
{
    public class Developer
    {
        public required Guid ID { get; set; }

        public required Credentials Credentials { get; set; }

        public List<Ticket>? Tickets { get; set; }

        public required int TicketCount { get; set; }

        public List<Customer>? Customers { get; set; }

        public required int CustomerCount { get; set; }

        public List<Application>? Applications { get; set; }
    }
}
