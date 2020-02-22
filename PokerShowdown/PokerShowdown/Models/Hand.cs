using PokerShowdown.Shared;
using PokerShowdown.Shared.Constants;
using PokerShowdown.Shared.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PokerShowdown.Models
{
    public class Hand
    {
        public List<Card> Cards { get; private set; }
        public HandRank HandRank { get => GetHandRank(Cards); }

        public Hand(List<string> rawCardData)
        {
            Cards = CreateCardsFromRaw(rawCardData);
        }

        /// <summary>
        /// Determines HandRank 
        /// </summary>
        /// <param name="cards">List<Card> representing a Player's cards in hand</param>
        /// <returns>HandRank corresponding to the rank of the Player's hand</returns>
        private HandRank GetHandRank(List<Card> cards)
        {
            HandRank handRank;
            if (PokerUtilities.IsFlush(cards))
            {
                handRank = HandRank.Flush;
            }
            else if (PokerUtilities.IsThreeOfAKind(cards))
            {
                handRank = HandRank.ThreeOfAKind;
            }
            else if (PokerUtilities.IsOnePair(cards))
            {
                handRank = HandRank.OnePair;
            }
            else
            {
                handRank = HandRank.HighCard;
            }

            return handRank;
        }

        /// <summary>
        /// Creates Cards property for an instance of Hand object
        /// </summary>
        /// <param name="rawCardData"></param>
        /// <returns>List<Card> of Cards making up the Hand</returns>
        private List<Card> CreateCardsFromRaw(List<string> rawCardData)
        {
            ValidateNoDuplicateCards(rawCardData);
            var cards = new List<Card>();

            if (rawCardData.Count != Constants.HAND_SIZE)
            {
                throw new InvalidHandLengthException($"Hand length must be {Constants.HAND_SIZE} cards, {rawCardData.Count} cards detected.");
            }

            foreach (string card in rawCardData)
            {
                cards.Add(new Card(card));
            }

            return cards;
        }

        /// <summary>
        /// Checks for duplicates prior to creating a new Hand and throws a DuplicateCardException
        /// </summary>
        /// <param name="rawCardData">List<string> of raw card values</param>
        private void ValidateNoDuplicateCards(List<string> rawCardData)
        {
            var duplicateCards = rawCardData.Distinct().Count() != rawCardData.Count;
            if (duplicateCards)
            {
                throw new DuplicateCardException("A hand cannot contain duplicate cards");
            }
        }
    }


}
