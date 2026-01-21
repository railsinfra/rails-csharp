using System.Net.Http;

namespace Rails.Exceptions;

public class RailsUnexpectedStatusCodeException : RailsApiException
{
    public RailsUnexpectedStatusCodeException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
