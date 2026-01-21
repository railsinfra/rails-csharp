using System.Net.Http;

namespace Rails.Exceptions;

public class RailsUnauthorizedException : Rails4xxException
{
    public RailsUnauthorizedException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
