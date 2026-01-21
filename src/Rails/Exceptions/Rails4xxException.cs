using System.Net.Http;

namespace Rails.Exceptions;

public class Rails4xxException : RailsApiException
{
    public Rails4xxException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
