namespace Starkit.Client.Application.Options;

using System.ComponentModel.DataAnnotations;

public class JsonFilesOptions
{
    [Required]
    public string Names { get; set; } = string.Empty;
}
