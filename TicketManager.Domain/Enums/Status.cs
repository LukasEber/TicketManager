using System.Runtime.Serialization;

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
