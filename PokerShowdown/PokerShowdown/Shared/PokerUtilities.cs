using PokerShowdown.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PokerShowdown.Shared
{
    public static class PokerUtilities
    {
        public static bool IsFlush(List<Card> cards)
        {
            return cards.All(c => c.Suit == cards.First().Suit);
        }

        public static bool IsThreeOfAKind(List<Card> cards)
        {
            return cards.GroupBy(c => c.Rank).Any(g => g.Count() == 3);
        }

        public static bool IsOnePair(List<Card> cards)
        {
            return cards.GroupBy(c => c.Rank).Any(g => g.Count() == 2);
        }
    }
}