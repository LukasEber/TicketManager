namespace TicketManager.Domain.Models
{
    public class Customer
    {
        public string Name { get; set; }
        public Guid ID { get; set; }
        public Credentials Credentials { get; set; }
        public Guid DeveloperID { get; set; } 
        public ICollection<Ticket>? Tickets { get; set; }
        public ICollection<string>? Applications { get; set; }
    }
}
