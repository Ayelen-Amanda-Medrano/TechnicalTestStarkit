namespace Starkit.Client.Domain;

public class GenericResponse<T>
{
    public T[] Response { get; set; } = Array.Empty<T>();
}
