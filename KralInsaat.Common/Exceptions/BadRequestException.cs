namespace KralInsaat.Common.Exceptions
{
    public class BadRequestException : AppException
    {
        public BadRequestException() : base() { }
        public BadRequestException(string message) : base(message) { }
    }
}
