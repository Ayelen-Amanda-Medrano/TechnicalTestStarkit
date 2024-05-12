using Starkit.Client.Api.Contracts.Enums;
using System.ComponentModel.DataAnnotations;

namespace Starkit.Client.Api.Contracts.Client;

public class ClientFilters
{
    [EnumDataType(typeof(Gender))]
    public string? Gender { get; set; }
    public string? Name { get; set; }
}
