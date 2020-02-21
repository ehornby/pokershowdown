using PokerShowdown.Models;
using PokerShowdown.Shared.Constants;
using PokerShowdown.Shared.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace PokerTests
{
    public class HandTests
    {
        [Fact]
        public void CreatesHandFromUserInput()
        {
            var parsedUserInput = new List<string>()
            {
                "3H",
                "5C",
                "4D",
                "QS",
                "AH"
            };
            var hand = new Hand(parsedUserInput);
            var expected = new List<Card>()
            {
                new Card("3H"),
                new Card("5C"),
                new Card("4D"),
                new Card("QS"),
                new Card("AH")

            };
            for (int i = 0; i < expected.Count; i++)
            {
                Assert.Equal(hand.Cards[i].Rank, expected[i].Rank);
                Assert.Equal(hand.Cards[i].Suit, expected[i].Suit);
            }
        }

        [Fact]
        public void ThrowsInvalidHandSizeException()
        {
            var inputFourCards = new List<string>()
            {
                "4C",
                "7D",
                "KC",
                "9C"
            };
            var inputSixCards = new List<string>()
            {
                "4C",
                "7D",
                "KC",
                "9C",
                "2D",
                "AS"
            };
            Assert.Throws<InvalidHandLengthException>(() => new Hand(inputFourCards));
            Assert.Throws<InvalidHandLengthException>(() => new Hand(inputSixCards));
        }

        [Fact]
        public void IdentifiesFlush()
        {
            var input = new List<string>()
            {
                "3H",
                "5H",
                "4H",
                "QH",
                "AH"
            };
            var hand = new Hand(input);
            Assert.Equal(HandRank.Flush, hand.HandRank);
        }

        [Fact]
        public void IdentifiesThreeOfAKind()
        {
            var input = new List<string>()
            {
                "3H",
                "3D",
                "3S",
                "QH",
                "AH"
            };
            var hand = new Hand(input);
            Assert.Equal(HandRank.ThreeOfAKind, hand.HandRank);
        }

        [Fact]
        public void IdentifiesOnePair()
        {
            var input = new List<string>()
            {
                "3H",
                "3D",
                "4C",
                "8D",
                "KS"
            };

            var hand = new Hand(input);
            Assert.Equal(HandRank.OnePair, hand.HandRank);
        }

        [Fact]
        public void IdentifiesHighCard()
        {
            var input = new List<string>()
            {
                "2C",
                "8D",
                "KD",
                "QC",
                "4S"
            };

            var hand = new Hand(input);
            Assert.Equal(HandRank.HighCard, hand.HandRank);
        }
    }
}
