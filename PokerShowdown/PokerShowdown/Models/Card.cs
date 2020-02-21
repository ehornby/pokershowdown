using System;
using System.Collections.Generic;
using System.Text;
using PokerShowdown.Shared.Constants;
using PokerShowdown.Shared.Exceptions;

namespace PokerShowdown.Models
{
    public class Card
    {
        public CardRank Rank { get; }
        public Suit Suit { get; }

        public Card(string rawCardValue)
        {
            Rank = ParseCardRankFromRaw(rawCardValue);
            Suit = ParseSuitFromRaw(rawCardValue);
        }

        public CardRank ParseCardRankFromRaw(string rawCardValue)
        {
            var cardRank = rawCardValue[0].ToString();
            switch (cardRank)
            {
                case "T":
                    return CardRank.Ten;
                case "J":
                    return CardRank.Jack;
                case "Q":
                    return CardRank.Queen;
                case "K":
                    return CardRank.King;
                case "A":
                    return CardRank.Ace;
                default:
                    break;
            }
            var isNumericCard = int.TryParse(cardRank, out var rankValue);
            if (!isNumericCard || rankValue == 0)
            {
                throw new RankNotValidException($"{rawCardValue} does not contain a valid rank");
            }

            return (CardRank)rankValue;
        }

        public Suit ParseSuitFromRaw(string rawCardValue)
        {
            var cardSuit = rawCardValue[1].ToString();
            switch (cardSuit)
            {
                case "C":
                    return Suit.Clubs;
                case "D":
                    return Suit.Diamonds;
                case "H":
                    return Suit.Hearts;
                case "S":
                    return Suit.Spades;
                default:
                    throw new SuitNotValidException($"{rawCardValue} does not contain a valid suit");
            }
        }
    }
}
