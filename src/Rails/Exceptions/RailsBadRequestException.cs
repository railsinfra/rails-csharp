using System.Net.Http;

namespace Rails.Exceptions;

public class RailsBadRequestException : Rails4xxException
{
    public RailsBadRequestException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
