using System;

namespace Rails.Exceptions;

public class RailsInvalidDataException : RailsException
{
    public RailsInvalidDataException(string message, Exception? innerException = null)
        : base(message, innerException) { }
}
