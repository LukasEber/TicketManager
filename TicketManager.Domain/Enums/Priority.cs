using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace TicketManager.Domain.Enums
{
    public enum Priority
    {
        [EnumMember(Value = "Urgent")]
        Urgent,
        [EnumMember(Value = "High")]
        High,
        [EnumMember(Value = "Medium")]
        Medium,
        [EnumMember(Value = "Low")]
        Low
    }
}
