namespace Starkit.Client.Application.Options;

using System.ComponentModel.DataAnnotations;

public class JsonFilesOptions
{
    [Required]
    public string Clients { get; set; } = string.Empty;
}
