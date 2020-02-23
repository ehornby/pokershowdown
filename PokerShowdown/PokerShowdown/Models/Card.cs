using PokerShowdown.Shared.Constants;
using PokerShowdown.Shared.Exceptions;

namespace PokerShowdown.Models
{
    public class Card
    {
        public CardRank Rank { get; }
        public Suit Suit { get; }

        /// <summary>
        /// Constructs a new instance of a Card object
        /// </summary>
        /// <param name="rawCardValue">String containing information about card rank and suit</param>
        /// <exception cref="CardDataInvalidException">Thrown when raw card data is not two characters in length</exception>
        public Card(string rawCardValue)
        {
            if (rawCardValue.Length != Constants.RAW_CARD_INPUT_SIZE)
            {
                throw new CardDataInvalidException("Raw card data must be two characters in length");
            }

            Rank = ParseCardRankFromRaw(rawCardValue);
            Suit = ParseSuitFromRaw(rawCardValue);
        }

        /// <summary>
        /// Parses card rank value from raw data
        /// </summary>
        /// <param name="rawCardValue">String containing information about card rank and suit</param>
        /// <returns>CardRank representing the rank of the card</returns>
        /// <exception cref="RankNotValidException">Thrown when raw data does not contain a valid rank</exception>
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

        /// <summary>
        /// Parses card suit value from raw data
        /// </summary>
        /// <param name="rawCardValue">String containing information about card rank and suit</param>
        /// <returns>Suit representing the suit of the card</returns>
        /// <exception cref="SuitNotValidException">Thrown when raw data does not contain a valid suit</exception>
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
