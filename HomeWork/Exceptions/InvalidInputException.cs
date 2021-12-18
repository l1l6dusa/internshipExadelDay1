using System;

namespace HomeWork2
{
    public class InvalidInputException : ArgumentException
    {
        public InvalidInputException(string message)
            : base(message)
        {
        }
    }
}