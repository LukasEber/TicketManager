namespace TicketManager.Domain.Models
{
    public class Developer
    {
        public required string Name { get; set; }

        public required Guid ID { get; set; }

        public required Credentials Credentials { get; set; }

        public List<Ticket>? Tickets { get; set; }

        public required int TicketCount { get; set; }

        public List<Customer>? Customers { get; set; }

        public required int CustomerCount { get; set; }

        public List<Application>? Applications { get; set; }
    }
}
