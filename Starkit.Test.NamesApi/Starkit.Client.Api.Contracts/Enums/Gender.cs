using System.Runtime.Serialization;

namespace Starkit.Client.Api.Contracts.Enums;

public enum Gender
{
    [EnumMember(Value = "Male")]
    M,
    [EnumMember(Value = "Female")]
    F,
}
