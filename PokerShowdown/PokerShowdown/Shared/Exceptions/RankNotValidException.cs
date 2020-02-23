using System;

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
