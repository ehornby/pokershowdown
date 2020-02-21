using PokerShowdown.Models;
using PokerShowdown.Shared.Constants;
using PokerShowdown.Shared.Exceptions;
using System;
using Xunit;

namespace PokerTests
{
    public class CardTests
    {
        [Fact]
        public void CreatesNumericAndFaceCardsWithCorrectInput()
        {
            var numericCardRawInput = "4H";
            var faceCardRawInput = "QC";

            var numericCard = new Card(numericCardRawInput);
            var faceCard = new Card(faceCardRawInput);

            Assert.Equal((CardRank)4, numericCard.Rank);
            Assert.Equal("Hearts", numericCard.Suit.ToString());

            Assert.Equal((CardRank)12, faceCard.Rank);
            Assert.Equal("Clubs", faceCard.Suit.ToString());
        }

        [Fact]
        public void ThrowsSuitNotValidException()
        {
            Assert.Throws<SuitNotValidException>(() => new Card("6X"));
        }

        [Fact]
        public void ThrowsRankNotValidException()
        {
            Assert.Throws<RankNotValidException>(() => new Card("HD"));
            Assert.Throws<RankNotValidException>(() => new Card("0C"));
        }
    }
}
