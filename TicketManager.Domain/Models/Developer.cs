namespace TicketManager.Domain.Models
{
    public class Developer
    {
        public  string Name { get; set; }

        public  Guid ID { get; set; }

        public  Credentials Credentials { get; set; }

        public List<Ticket>? Tickets { get; set; }

        public  int TicketCount { get; set; }

        public List<Customer>? Customers { get; set; }

        public  int CustomerCount { get; set; }

        public List<Application>? Applications { get; set; }
    }
}
