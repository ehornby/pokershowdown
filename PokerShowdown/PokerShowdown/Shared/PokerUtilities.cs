using PokerShowdown.Models;
using System.Collections.Generic;
using System.Linq;

namespace PokerShowdown.Shared
{
    public static class PokerUtilities
    {
        /// <summary>
        /// Tests if a group of cards qualifies as a flush
        /// </summary>
        /// <param name="cards">List<Card> representing the cards in a player's hand</param>
        /// <returns>Bool representing whether or not a flush is found</returns>
        public static bool IsFlush(List<Card> cards)
        {
            return cards.All(c => c.Suit == cards.First().Suit);
        }

        /// <summary>
        /// Tests if a group of cards qualifies as three of a kind
        /// </summary>
        /// <param name="cards">List<Card> representing the cards in a player's hand</param>
        /// <returns>Bool representing whether or not three of a kind is found</returns>
        public static bool IsThreeOfAKind(List<Card> cards)
        {
            return cards
                .GroupBy(c => c.Rank)
                .Any(g => g.Count() >= 3);
        }

        /// <summary>
        /// Tests if a group of cards qualifies as one pair
        /// </summary>
        /// <param name="cards">List<Card> representing the cards in a player's hand</param>
        /// <returns>Bool representing whether or not one pair is found</returns>
        public static bool IsOnePair(List<Card> cards)
        {
            return cards
                .GroupBy(c => c.Rank)
                .Any(g => g.Count() == 2);
        }
    }
}