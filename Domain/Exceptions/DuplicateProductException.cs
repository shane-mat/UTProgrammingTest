namespace Domain.Exceptions
{
    [Serializable]
    public class DuplicateProductException : Exception
    {
        public DuplicateProductException() { }

        public DuplicateProductException(string message)
            : base(message) { }
    }
}