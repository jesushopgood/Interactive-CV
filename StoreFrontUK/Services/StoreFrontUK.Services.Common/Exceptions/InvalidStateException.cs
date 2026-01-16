namespace StoreFrontUK.Services.Common.Exceptions;

public class InvalidStateException : Exception
{
    public InvalidStateException(string message) : base(message){}
}