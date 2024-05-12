﻿namespace Domain.Exceptions
{
    [Serializable]
    public class ProductNotFoundException : Exception
    {
        public ProductNotFoundException() { }

        public ProductNotFoundException(string message)
            : base(message) { }
    }
}