using System.Net.Http;

namespace Rails.Exceptions;

public class Rails5xxException : RailsApiException
{
    public Rails5xxException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
