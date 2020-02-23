using System;

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
