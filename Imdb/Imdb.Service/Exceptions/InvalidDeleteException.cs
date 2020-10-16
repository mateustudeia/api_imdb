using System;
using System.Collections.Generic;
using System.Text;

namespace Imdb.Service.Exceptions
{
    public class InvalidDeleteException : Exception
    {
        public InvalidDeleteException(string message) : base(message) {}
    }
}
