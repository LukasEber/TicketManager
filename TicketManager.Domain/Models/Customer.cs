namespace TicketManager.Domain.Models
{
    public class Customer
    {
        public  string Name { get; set; }

        public  Guid ID { get; set; }

        public  Credentials Credentials { get; set; }

        public  Developer Developer { get; set; }

        public  int TicketCount { get; set; }

        public  List<Ticket> Tickets { get; set; }

        public List<Application>? Applications { get; set; }
    }
}
