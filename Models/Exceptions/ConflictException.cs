namespace Monster_Builder_Web_API.Models.Exceptions;

public class ConflictException : Exception
{
    public ConflictException(string message) : base(message) { }
}
