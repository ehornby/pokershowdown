using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace PokerShowdown.Shared.Constants
{
    public enum CardRank
    {
        None = -1,
        Two = 2,
        Three = 3,
        Four = 4,
        Five = 5,
        Six = 6,
        Seven = 7,
        Eight = 8,
        Nine = 9,
        Ten = 10,
        Jack = 11,
        Queen = 12,
        King = 13,
        Ace = 14
    }

    public enum HandRank
    {
        [Description("High Card")] HighCard,
        [Description("One Pair")] OnePair,
        [Description("Three of a Kind")] ThreeOfAKind,
        [Description("Flush")] Flush
    }

    public enum Suit
    {
        Clubs,
        Diamonds,
        Hearts,
        Spades
    }
}
