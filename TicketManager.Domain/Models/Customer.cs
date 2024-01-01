namespace TicketManager.Domain.Models
{
    public class Customer
    {
        public required string Name { get; set; }

        public required Guid ID { get; set; }

        public required Credentials Credentials { get; set; }

        public required Guid DeveloperID { get; set; }

        public required int TicketCount { get; set; }

        public required List<Ticket> Tickets { get; set; }

        public List<Application>? Applications { get; set; }
    }
}
