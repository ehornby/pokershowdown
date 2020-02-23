using System;

namespace PokerShowdown.Shared.Exceptions
{
    public class DuplicateCardException : Exception
    {
        public DuplicateCardException(string message) : base(message) { }
    }
}
