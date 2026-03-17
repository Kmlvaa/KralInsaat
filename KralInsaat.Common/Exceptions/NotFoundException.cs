namespace KralInsaat.Common.Exceptions
{
    public class NotFoundException : AppException
    {
        public NotFoundException() : base() { }
        public NotFoundException(string message) : base(message) { }
    }
}
 