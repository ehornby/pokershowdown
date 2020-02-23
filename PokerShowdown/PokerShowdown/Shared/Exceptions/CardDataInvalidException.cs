using System;

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
