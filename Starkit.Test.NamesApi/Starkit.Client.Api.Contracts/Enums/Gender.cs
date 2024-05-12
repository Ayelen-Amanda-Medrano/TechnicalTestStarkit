using System.Runtime.Serialization;

namespace Starkit.Client.Api.Contracts.Enums;

public enum Gender
{
    [EnumMember(Value = "Male")]
    M = 1,
    [EnumMember(Value = "Female")]
    F,
}
