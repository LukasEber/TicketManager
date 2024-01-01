using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace TicketManager.Domain.Models
{
    public class Customer
    {
        public required Guid ID { get; set; }

        public required Credentials Credentials { get; set; }

        public required Guid DeveloperID { get; set; }

        public required int TicketCount { get; set; }

        public required List<Ticket> Tickets { get; set; }
    }
}
