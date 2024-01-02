using System.ComponentModel.DataAnnotations;

namespace TicketManager.Domain.Models
{
    public class Credentials
    {
        [Key]
        public  string MailAddress { get; set; }

        public  string Password { get; set; }
    }
}
