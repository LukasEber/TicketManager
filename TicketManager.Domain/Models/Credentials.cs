using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketManager.Domain.Models
{
    public class Credentials
    {
        public required string Name { get; set; }

        public required string MailAddress { get; set; }

        public required string Password { get; set; }
    }
}
