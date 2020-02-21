using System;
using System.Collections.Generic;
using System.Text;

namespace PokerShowdown.Shared.Exceptions
{
    public class InvalidHandLengthException : Exception
    {
        public InvalidHandLengthException(string message)
        {
            Console.WriteLine(message);
        }
    }
}
