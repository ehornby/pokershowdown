using PokerShowdown.Shared;
using PokerShowdown.Shared.Constants;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace PokerTests
{
    public partial class TieBreakTests
    {
        [Fact]
        public void ReturnsFlushWinnerNoMatchingCards()
        {
            var player1 = new Player("Player1, 5C, 6C, 7C, 8C, 4C");
            var player2 = new Player("Player2, 6D, 7D, 8D, 9D, AD");
            var player3 = new Player("Player3, 6H, 2H, 3H, AH, KH");
            var player4 = new Player("Player4, 6S, 7S, 8S, QS, JS");
            var players = new List<Player> { player1, player2, player3, player4 };
            var winners = new List<Player> { player3 };

            Assert.True(players.TrueForAll(player => PokerUtilities.IsFlush(player.Hand.Cards)));

            Assert.Equal(winners, TieBreak.BreakHighCardOrFlushTies(players));
        }

        [Fact]
        public void ReturnsFlushWinnerWithOneMatchingHighCard()
        {
            var player1 = new Player("Player1, 6C, 7C, 8C, 9C, KC");
            var player2 = new Player("Player2, 2D, 3D, 4D, QD, KD");
            var player3 = new Player("Player3, 5H, 7H, 9H, 2H, KH");
            var player4 = new Player("Player4, 6S, 8S, 9S, KS, 5S");
            var players = new List<Player> { player1, player2, player3, player4 };
            var winners = new List<Player> { player2 };

            Assert.True(players.TrueForAll(player => PokerUtilities.IsFlush(player.Hand.Cards)));

            Assert.Equal(winners, TieBreak.BreakHighCardOrFlushTies(players));
        }

        [Fact]
        public void ReturnsFlushWinnerWithTwoMatchingHighCards()
        {
            var player1 = new Player("Player1, 6C, 7C, 8C, QC, KC");
            var player2 = new Player("Player2, 2D, 3D, 4D, QD, KD");
            var player3 = new Player("Player3, 5H, 7H, 9H, 2H, KH");
            var player4 = new Player("Player4, 6S, 8S, 9S, KS, 5S");
            var players = new List<Player> { player1, player2, player3, player4 };
            var winners = new List<Player> { player1 };

            Assert.True(players.TrueForAll(player => PokerUtilities.IsFlush(player.Hand.Cards)));

            Assert.Equal(winners, TieBreak.BreakHighCardOrFlushTies(players));
        }

        [Fact]
        public void ReturnsFlushWinnerWithThreeMatchingHighCards()
        {
            var player1 = new Player("Player1, 6C, 7C, 9C, QC, KC");
            var player2 = new Player("Player2, 2D, 3D, 9D, QD, KD");
            var player3 = new Player("Player3, 5H, 8H, 9H, QH, KH");
            var player4 = new Player("Player4, 6S, 8S, 9S, KS, 5S");
            var players = new List<Player> { player1, player2, player3, player4 };
            var winners = new List<Player> { player3 };

            Assert.True(players.TrueForAll(player => PokerUtilities.IsFlush(player.Hand.Cards)));

            Assert.Equal(winners, TieBreak.BreakHighCardOrFlushTies(players));
        }

        [Fact]
        public void ReturnsFlushWinnerWithFourMatchingCards()
        {
            var player1 = new Player("Player1, 6C, 8C, 9C, QC, AC");
            var player2 = new Player("Player2, 7D, 8D, 9D, QD, AD");
            var player3 = new Player("Player3, 5H, 8H, 9H, QH, AH");
            var player4 = new Player("Player4, 6S, 8S, 9S, KS, 5S");
            var players = new List<Player> { player1, player2, player3, player4 };
            var winners = new List<Player> { player2 };

            Assert.True(players.TrueForAll(player => PokerUtilities.IsFlush(player.Hand.Cards)));

            Assert.Equal(winners, TieBreak.BreakHighCardOrFlushTies(players));
        }

        [Fact]
        public void ReturnsMultipleFlushWinners()
        {
            var player1 = new Player("Player1, 7C, 8C, 9C, QC, AC");
            var player2 = new Player("Player2, 7D, 8D, 9D, QD, AD");
            var player3 = new Player("Player3, 5H, 8H, 9H, QH, AH");
            var player4 = new Player("Player4, 6S, 8S, 9S, KS, 5S");
            var players = new List<Player> { player1, player2, player3, player4 };
            var winners = new List<Player> { player1, player2 };

            Assert.True(players.TrueForAll(player => PokerUtilities.IsFlush(player.Hand.Cards)));

            Assert.Equal(winners, TieBreak.BreakHighCardOrFlushTies(players));
        }

        [Fact]
        public void ReturnsHighCardWinnerNoMatchingCards()
        {
            var player1 = new Player("Player1, 6C, 3D, KD, 7H, JS");
            var player2 = new Player("Player2, 4D, AD, 6H, 2H, QH");
            var player3 = new Player("Player3, 3H, 5D, 9D, TC, JC");
            var player4 = new Player("Player4, TS, 4S, 8C, JH, 2S");
            var players = new List<Player> { player1, player2, player3, player4 };
            var winners = new List<Player> { player2 };

            Assert.Equal(winners, TieBreak.BreakHighCardOrFlushTies(players));
        }

        [Fact]
        public void ReturnsHighCardWinnerOneMatchingCard()
        {
            var player1 = new Player("Player1, 6C, 3D, KD, 7H, JS");
            var player2 = new Player("Player2, 4D, AD, 6H, 2H, QH");
            var player3 = new Player("Player3, 3H, 5D, 9D, AC, KC");
            var player4 = new Player("Player4, TS, 4S, 8C, JH, 2S");
            var players = new List<Player> { player1, player2, player3, player4 };
            var winners = new List<Player> { player3 };

            Assert.Equal(winners, TieBreak.BreakHighCardOrFlushTies(players));
        }

        [Fact]
        public void ReturnsHighCardWinnerTwoMatchingCards()
        {
            var player1 = new Player("Player1, 6C, 3D, KD, 7H, JS");
            var player2 = new Player("Player2, 4D, AD, 6H, 2H, QH");
            var player3 = new Player("Player3, 3H, 5D, 9D, AC, KC");
            var player4 = new Player("Player4, TS, 4S, AC, JH, KS");
            var players = new List<Player> { player1, player2, player3, player4 };
            var winners = new List<Player> { player4 };

            Assert.Equal(winners, TieBreak.BreakHighCardOrFlushTies(players));
        }

        [Fact]
        public void ReturnsHighCardWinnerThreeMatchingCards()
        {
            var player1 = new Player("Player1, AC, 3D, KD, 7H, JS");
            var player2 = new Player("Player2, 4D, AD, 6H, 2H, QH");
            var player3 = new Player("Player3, 3H, JD, 9D, AC, KC");
            var player4 = new Player("Player4, 2S, 4S, AC, JH, KS");
            var players = new List<Player> { player1, player2, player3, player4 };
            var winners = new List<Player> { player3 };

            Assert.Equal(winners, TieBreak.BreakHighCardOrFlushTies(players));
        }

        [Fact]
        public void ReturnsHighCardWinnerFourMatchingCards()
        {
            var player1 = new Player("Player1, AC, 9D, KD, 7H, JS");
            var player2 = new Player("Player2, 4D, AD, 6H, 2H, QH");
            var player3 = new Player("Player3, 3H, JD, 9C, AC, KC");
            var player4 = new Player("Player4, 9S, 4S, AC, JH, KS");
            var players = new List<Player> { player1, player2, player3, player4 };
            var winners = new List<Player> { player1 };

            Assert.Equal(winners, TieBreak.BreakHighCardOrFlushTies(players));
        }

        [Fact]
        public void ReturnsMultipleHighCardWinners()
        {
            var player1 = new Player("Player1, AC, 9D, KD, 7H, JS");
            var player2 = new Player("Player2, 4D, AD, 6H, 2H, QH");
            var player3 = new Player("Player3, 7D, JD, 9C, AC, KC");
            var player4 = new Player("Player4, 9S, 4S, AC, JH, KS");
            var players = new List<Player> { player1, player2, player3, player4 };
            var winners = new List<Player> { player1, player3 };

            Assert.Equal(winners, TieBreak.BreakHighCardOrFlushTies(players));
        }
    }
}
