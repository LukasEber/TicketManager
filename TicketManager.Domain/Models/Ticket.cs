using TicketManager.Domain.Enums;

namespace TicketManager.Domain.Models
{
    public class Ticket
    {
        public Guid ID { get; set; }

        public Guid CustomerID { get; set; }

        public Guid DeveloperID { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public Application Application { get; set; }

        public Priority Priority { get; set; }

        public Status Status { get; set; }

        public List<string> Attachments { get; set; }

        public string Comment { get; set; }

    }
}
