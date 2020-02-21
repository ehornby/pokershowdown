using System;
using System.Collections.Generic;
using System.Text;

namespace PokerShowdown.Shared.Exceptions
{
    public class SuitNotValidException : Exception
    {
        public SuitNotValidException(string message)
        {
            Console.WriteLine(message);
        }
    }
}
