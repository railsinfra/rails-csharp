using System;
using System.Net.Http;

namespace Rails.Exceptions;

public class RailsException : Exception
{
    public RailsException(string message, Exception? innerException = null)
        : base(message, innerException) { }

    protected RailsException(HttpRequestException? innerException)
        : base(null, innerException) { }
}
