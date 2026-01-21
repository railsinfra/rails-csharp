using System.Net.Http;

namespace Rails.Exceptions;

public class RailsUnprocessableEntityException : Rails4xxException
{
    public RailsUnprocessableEntityException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
