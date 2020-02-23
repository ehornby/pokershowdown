using PokerShowdown.Models;
using PokerShowdown.Shared.Constants;
using PokerShowdown.Shared.Exceptions;
using Xunit;

namespace PokerTests
{
    public class CardTests
    {
        [Fact]
        public void CreatesCorrectCardWithInputRankTwo()
        {
            var numericCardRawInput = "2S";

            var numericCard = new Card(numericCardRawInput);

            Assert.Equal(CardRank.Two, numericCard.Rank);
            Assert.Equal(Suit.Spades, numericCard.Suit);
        }

        [Fact]
        public void CreatesCorrectCardWithInputRankThree()
        {
            var numericCardRawInput = "3S";

            var numericCard = new Card(numericCardRawInput);

            Assert.Equal(CardRank.Three, numericCard.Rank);
            Assert.Equal(Suit.Spades, numericCard.Suit);
        }

        [Fact]
        public void CreatesCorrectCardWithInputRankFour()
        {
            var numericCardRawInput = "4S";

            var numericCard = new Card(numericCardRawInput);

            Assert.Equal(CardRank.Four, numericCard.Rank);
            Assert.Equal(Suit.Spades, numericCard.Suit);
        }

        [Fact]
        public void CreatesCorrectCardWithInputRankFive()
        {
            var numericCardRawInput = "5S";

            var numericCard = new Card(numericCardRawInput);

            Assert.Equal(CardRank.Five, numericCard.Rank);
            Assert.Equal(Suit.Spades, numericCard.Suit);
        }

        [Fact]
        public void CreatesCorrectCardWithInputRankSix()
        {
            var numericCardRawInput = "6S";

            var numericCard = new Card(numericCardRawInput);

            Assert.Equal(CardRank.Six, numericCard.Rank);
            Assert.Equal(Suit.Spades, numericCard.Suit);
        }

        [Fact]
        public void CreatesCorrectCardWithInputRankSeven()
        {
            var numericCardRawInput = "7S";

            var numericCard = new Card(numericCardRawInput);

            Assert.Equal(CardRank.Seven, numericCard.Rank);
            Assert.Equal(Suit.Spades, numericCard.Suit);
        }

        [Fact]
        public void CreatesCorrectCardWithInputRankEight()
        {
            var numericCardRawInput = "8S";

            var numericCard = new Card(numericCardRawInput);

            Assert.Equal(CardRank.Eight, numericCard.Rank);
            Assert.Equal(Suit.Spades, numericCard.Suit);
        }

        [Fact]
        public void CreatesCorrectCardWithInputRankNine()
        {
            var numericCardRawInput = "9S";

            var numericCard = new Card(numericCardRawInput);

            Assert.Equal(CardRank.Nine, numericCard.Rank);
            Assert.Equal(Suit.Spades, numericCard.Suit);
        }

        [Fact]
        public void CreatesCorrectCardWithInputRankTen()
        {
            var numericCardRawInput = "TS";

            var numericCard = new Card(numericCardRawInput);

            Assert.Equal(CardRank.Ten, numericCard.Rank);
            Assert.Equal(Suit.Spades, numericCard.Suit);
        }

        [Fact]
        public void CreatesCorrectCardWithInputRankJack()
        {
            var numericCardRawInput = "JS";

            var numericCard = new Card(numericCardRawInput);

            Assert.Equal(CardRank.Jack, numericCard.Rank);
            Assert.Equal(Suit.Spades, numericCard.Suit);
        }

        [Fact]
        public void CreatesCorrectCardWithInputRankQueen()
        {
            var numericCardRawInput = "QS";

            var numericCard = new Card(numericCardRawInput);

            Assert.Equal(CardRank.Queen, numericCard.Rank);
            Assert.Equal(Suit.Spades, numericCard.Suit);
        }

        [Fact]
        public void CreatesCorrectCardWithInputRankKing()
        {
            var numericCardRawInput = "KS";

            var numericCard = new Card(numericCardRawInput);

            Assert.Equal(CardRank.King, numericCard.Rank);
            Assert.Equal(Suit.Spades, numericCard.Suit);
        }

        [Fact]
        public void CreatesCorrectCardWithInputRankAce()
        {
            var numericCardRawInput = "AS";

            var numericCard = new Card(numericCardRawInput);

            Assert.Equal(CardRank.Ace, numericCard.Rank);
            Assert.Equal(Suit.Spades, numericCard.Suit);
        }

        [Fact]
        public void CreatesCorrectCardWithInputSuitHearts()
        {
            var numericCardRawInput = "2H";

            var numericCard = new Card(numericCardRawInput);

            Assert.Equal(CardRank.Two, numericCard.Rank);
            Assert.Equal(Suit.Hearts, numericCard.Suit);
        }

        [Fact]
        public void CreatesCorrectCardWithInputSuitDiamonds()
        {
            var numericCardRawInput = "2D";

            var numericCard = new Card(numericCardRawInput);

            Assert.Equal(CardRank.Two, numericCard.Rank);
            Assert.Equal(Suit.Diamonds, numericCard.Suit);
        }

        [Fact]
        public void CreatesCorrectCardWithInputSuitClubs()
        {
            var numericCardRawInput = "2C";

            var numericCard = new Card(numericCardRawInput);

            Assert.Equal(CardRank.Two, numericCard.Rank);
            Assert.Equal(Suit.Clubs, numericCard.Suit);
        }

        [Fact]
        public void ThrowsExceptionWhenSuitDataInvalid()
        {
            Assert.Throws<SuitNotValidException>(() => new Card("6X"));
        }

        [Fact]
        public void ThrowsExceptionWhenRankDataInvalid()
        {
            Assert.Throws<RankNotValidException>(() => new Card("HD"));
        }

        [Fact]
        public void ThrowsRankNotValidExceptionWithZeroRank()
        {
            Assert.Throws<RankNotValidException>(() => new Card("0C"));
        }

        [Fact]
        public void ThrowsExceptionWhenRawDataIncorrectLength()
        {
            Assert.Throws<CardDataInvalidException>(() => new Card("10D"));
        }
    }
}
