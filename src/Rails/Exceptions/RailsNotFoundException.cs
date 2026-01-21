using System.Net.Http;

namespace Rails.Exceptions;

public class RailsNotFoundException : Rails4xxException
{
    public RailsNotFoundException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
