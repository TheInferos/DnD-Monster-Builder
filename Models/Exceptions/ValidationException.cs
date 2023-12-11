namespace Monster_Builder_Web_API.Models.Exceptions
{
    public class ValidationException : AggregateException
    {
        public ValidationException(params Exception[] innerExceptions) : base (innerExceptions) { }
    }
}
