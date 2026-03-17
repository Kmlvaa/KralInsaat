namespace KralInsaat.Common.Exceptions
{
    public class UnauthorizedException : AppException
    {
        public UnauthorizedException() : base() { }
        public UnauthorizedException(string message) : base(message) { }
    }
}
 