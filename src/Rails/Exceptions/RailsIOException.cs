using System;
using System.Net.Http;

namespace Rails.Exceptions;

public class RailsIOException : RailsException
{
    public new HttpRequestException InnerException
    {
        get
        {
            if (base.InnerException == null)
            {
                throw new ArgumentNullException();
            }
            return (HttpRequestException)base.InnerException;
        }
    }

    public RailsIOException(string message, HttpRequestException? innerException = null)
        : base(message, innerException) { }
}
