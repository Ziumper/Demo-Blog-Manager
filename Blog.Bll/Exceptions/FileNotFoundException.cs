using System;

namespace Blog.Bll.Exceptions {

    public class FileNotFoundException : Exception {
         public FileNotFoundException(string message) : base(message)
        {

        }
    }
}