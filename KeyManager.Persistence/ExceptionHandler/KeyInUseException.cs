namespace KeyManager.ExceptionHandler
{
    [Serializable]
    internal class KeyInUseException : Exception
    {
        public KeyInUseException()
        {
        }

        public KeyInUseException(string? message) : base(message)
        {
        }

        public KeyInUseException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}