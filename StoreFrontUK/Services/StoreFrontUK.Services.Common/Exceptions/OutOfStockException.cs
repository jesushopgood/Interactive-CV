namespace StoreFrontUK.Services.Common.Exceptions;

public class OutOfStockException : Exception
{
    public OutOfStockException(string message) : base(message) { }
}