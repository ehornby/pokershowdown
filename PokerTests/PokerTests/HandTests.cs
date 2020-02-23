using PokerShowdown.Models;
using PokerShowdown.Shared.Constants;
using PokerShowdown.Shared.Exceptions;
using System.Collections.Generic;
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
                Assert.Equal(expected[i].Rank, hand.Cards[i].Rank);
                Assert.Equal(expected[i].Suit, hand.Cards[i].Suit);
            }
        }

        [Fact]
        public void ThrowsInvalidHandSizeExceptionForTooFewCards()
        {
            var inputFourCards = new List<string>()
            {
                "4C",
                "7D",
                "KC",
                "9C"
            };
            Assert.Throws<InvalidHandLengthException>(() => new Hand(inputFourCards));
        }

        [Fact]
        public void ThrowsInvalidHandSizeExceptionForTooManyCards()
        {
            var inputSixCards = new List<string>()
            {
                "4C",
                "7D",
                "KC",
                "9C",
                "2D",
                "AS"
            };
            Assert.Throws<InvalidHandLengthException>(() => new Hand(inputSixCards));
        }

        [Fact]
        public void DetectsDuplicateCards()
        {
            var input = new List<string>()
            {
                "5C",
                "4D",
                "4D",
                "7S",
                "AS"
            };
            Assert.Throws<DuplicateCardException>(() => new Hand(input));
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
        public void IdentifiesThreeOfAKindWithThreeMatching()
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
        public void IdentifyThreeOfAKindWithFourMatching()
        {
            var input = new List<string>()
            {
                "3H",
                "3D",
                "3S",
                "3C",
                "AH"
            };
            var hand = new Hand(input);
            Assert.Equal(HandRank.ThreeOfAKind, hand.HandRank);
        }

        [Fact]
        public void IdentifyThreeOfAKindWithAdditionalPair()
        {
            var input = new List<string>()
            {
                "3H",
                "3D",
                "3S",
                "AC",
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
        public void IdentifiesOnePairWithAdditionalPair()
        {
            var input = new List<string>()
            {
                "3H",
                "3D",
                "4C",
                "4D",
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
