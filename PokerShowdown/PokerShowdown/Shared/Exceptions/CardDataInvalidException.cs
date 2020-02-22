using System;
using System.Collections.Generic;
using System.Text;

namespace PokerShowdown.Shared.Exceptions
{
    public class CardDataInvalidException: Exception
    {
        public CardDataInvalidException(string message)
        {
            Console.WriteLine(message);
        }
    }
}
