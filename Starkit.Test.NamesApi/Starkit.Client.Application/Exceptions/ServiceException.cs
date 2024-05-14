using System.Net;

namespace Starkit.Client.Application.Exceptions;

public class ServiceException : Exception
{
    public HttpStatusCode HttpStatusCode { get; }

    public ServiceException(HttpStatusCode errorCode, string message) : base(message)
    {
        HttpStatusCode = errorCode;
    }
}