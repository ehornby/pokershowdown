using System;

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
