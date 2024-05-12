namespace Domain.Exceptions
{
    [Serializable]
    public class InvalidInputException : Exception
    {
        public InvalidInputException() { }

        public InvalidInputException(string message)
            : base(message) { }
    }
}