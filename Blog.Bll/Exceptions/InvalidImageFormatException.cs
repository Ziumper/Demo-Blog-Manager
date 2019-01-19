using System;

namespace Blog.Bll.Exceptions
{
    public class InvalidImageFormatException : Exception
    {
        public InvalidImageFormatException(string message) : base(message)
        {

        }
    }
}
