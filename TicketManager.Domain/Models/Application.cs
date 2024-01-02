using System.ComponentModel.DataAnnotations;

namespace TicketManager.Domain.Models
{
    public class Application
    {
        [Key]
        public  string Name { get; set; }
    }
}
