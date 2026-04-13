using System.Runtime.Serialization;

namespace WebApplication1.Enums;

public enum ReservationStatus
{
    [EnumMember(Value = "planned")]
    Planned,
    [EnumMember(Value = "confirmed")]
    Confirmed,
    [EnumMember(Value = "cancelled")]
    Cancelled
}