namespace KralInsaat.Common.Exceptions
{
    public abstract class AppException : Exception
    {
        public string ClientMessage { get; }
        public AppException() : base() { }

        public AppException(string message) :base(message)
        {
            ClientMessage = message;
        }

        public AppException(string clientMessage, Exception inner) : base(clientMessage, inner)
        {
            ClientMessage = clientMessage;
        }
    }
}
