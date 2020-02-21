using PokerShowdown.Shared;
using PokerShowdown.Shared.Constants;
using PokerShowdown.Shared.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace PokerShowdown.Models
{
    public class Hand
    {
        public List<Card> Cards { get; }
        public HandRank HandRank { get => GetHandRank(Cards); }

        public Hand(List<string> parsedInput)
        {
            Cards = CreateCardsFromRaw(parsedInput);
        }

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

        private List<Card> CreateCardsFromRaw(List<string> parsedInput)
        {
            var cards = new List<Card>();

            if (parsedInput.Count != 5)
            {
                throw new InvalidHandLengthException("Hand length must be five cards");
            }

            foreach (string card in parsedInput)
            {
                cards.Add(new Card(card));
            }

            return cards;
        }
    }


}
