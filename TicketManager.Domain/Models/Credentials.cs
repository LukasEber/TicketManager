using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace TicketManager.Domain.Models
{
    [Owned]
    public class Credentials
    {
        public  string MailAddress { get; set; }

        public  string Password { get; set; }
    }
}
