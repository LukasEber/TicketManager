using System.Collections.Generic;
using TicketManager.Domain.Enums;

namespace TicketManager.Domain.Models
{
    public class Ticket
    {
        public Guid ID { get; set; }
        public Guid AssignedCustomerID { get; set; }
        public Guid AssignedDeveloperID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Application { get; set; }
        public Priority Priority { get; set; }
        public Status Status { get; set; }
        public ICollection<string> Attachments { get; set; }
        public string Comment { get; set; }

    }
}
