using System.Net.Http;

namespace Rails.Exceptions;

public class RailsRateLimitException : Rails4xxException
{
    public RailsRateLimitException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
