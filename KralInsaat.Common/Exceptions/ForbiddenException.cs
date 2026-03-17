namespace KralInsaat.Common.Exceptions
{
    public class ForbiddenException : AppException
    {
        public ForbiddenException() : base() { }
        public ForbiddenException(string message) : base(message) { }
    }
}
