﻿using System.ComponentModel;

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
        HighCard,
        OnePair,
        ThreeOfAKind,
        Flush
    }

    public enum Suit
    {
        Clubs,
        Diamonds,
        Hearts,
        Spades
    }
}
