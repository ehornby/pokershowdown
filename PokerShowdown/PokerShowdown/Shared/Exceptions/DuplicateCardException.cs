using System;
using System.Collections.Generic;
using System.Text;

namespace PokerShowdown.Shared.Exceptions
{
    public class DuplicateCardException : Exception
    {
        public DuplicateCardException(string message)
        {
            Console.WriteLine(message);
        }
    }
}
