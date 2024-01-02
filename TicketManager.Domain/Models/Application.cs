using System.ComponentModel.DataAnnotations;

namespace TicketManager.Domain.Models
{
    public class Application
    {
        [Key]
        public required string Name { get; set; }
    }
}
