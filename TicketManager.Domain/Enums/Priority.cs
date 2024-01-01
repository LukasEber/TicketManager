using System.Runtime.Serialization;

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
