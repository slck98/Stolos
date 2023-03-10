namespace BusinessLayer.Exceptions;

internal class DomainException : Exception
{
    internal DomainException(string message) : base(message) { }
    internal DomainException(string message, Exception inner) : base(message, inner) { }
}
