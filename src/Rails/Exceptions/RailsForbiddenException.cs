using System.Net.Http;

namespace Rails.Exceptions;

public class RailsForbiddenException : Rails4xxException
{
    public RailsForbiddenException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
