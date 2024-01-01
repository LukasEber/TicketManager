using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace TicketManager.Domain.Enums
{
    public enum Status
    {
        [EnumMember(Value = "ToDo")]
        ToDo,
        [EnumMember(Value = "InProgress")]
        InProgress,
        [EnumMember(Value = "Done")]
        Done
    }
}
