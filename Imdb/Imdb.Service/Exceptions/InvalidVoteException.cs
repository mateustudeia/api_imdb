using System;
using System.Collections.Generic;
using System.Text;

namespace Imdb.Service.Exceptions
{
    public class InvalidVoteException : Exception
    {
        public InvalidVoteException(string message) : base(message) { }
    }
}
