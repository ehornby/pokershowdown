using System;
using System.Collections.Generic;
using System.Text;

namespace PokerShowdown.Shared.Exceptions
{
    public class RankNotValidException : Exception
    {
        public RankNotValidException(string message)
        {
            Console.WriteLine(message);
        }
    }
}
