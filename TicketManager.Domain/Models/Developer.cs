namespace TicketManager.Domain.Models
{
    public class Developer
    {
        public string Name { get; set; }
        public Guid ID { get; set; }
        public Credentials Credentials { get; set; }
        public ICollection<Ticket>? Tickets { get; set; }
        public ICollection<Customer>? AssignedCustomers { get; set; } 
        public ICollection<string>? Applications { get; set; }
    }
}
