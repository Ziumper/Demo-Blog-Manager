using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Bll.Exceptions
{
    public class ResourceNotFoundException : Exception
    {
        public ResourceNotFoundException(string message) : base(message)
        {
           
        }
    }
}
