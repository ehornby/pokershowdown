using PokerShowdown.Shared;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace PokerTests
{
    public partial class TieBreakTests
    {
        [Fact]
        public void ReturnsOnePairWinnerWhenPairsDifferent()
        {
            var player1 = new Player("Player1, 3C, 3D, 8S, AC, KH");
            var player2 = new Player("Player2, 4H, 3S, QH, TC, 4C");
            var player3 = new Player("Player3, 2D, 2H, 5S, 9S, JC");

            var players = new List<Player>() { player1, player2, player3 };
            var winners = new List<Player>() { player2 };

            Assert.True(players.TrueForAll(player => PokerUtilities.IsOnePair(player.Hand.Cards)));

            Assert.Equal(winners, TieBreak.BreakOnePairTies(players));
        }

        [Fact]
        public void ReturnsOnePairWinnerWithSamePairsNoMatchingKicker()
        {
            var player1 = new Player("Player1, 4S, 4D, 8S, 2C, KH");
            var player2 = new Player("Player2, 4H, 3S, QH, AC, 4C");
            var player3 = new Player("Player3, 2D, 2H, 6S, 9S, JC");

            var players = new List<Player>() { player1, player2, player3 };
            var winners = new List<Player>() { player2 };

            Assert.True(players.TrueForAll(player => PokerUtilities.IsOnePair(player.Hand.Cards)));

            Assert.Equal(winners, TieBreak.BreakOnePairTies(players));
        }

        [Fact]
        public void ReturnsOnePairWinnerWithSamePairsAndMatchingKicker()
        {
            var player1 = new Player("Player1, 2D, 2H, 6S, 9S, JC");
            var player2 = new Player("Player2, 4H, 3S, KH, AC, 4C");
            var player3 = new Player("Player3, 4H, 3S, QH, AC, 4C");

            var players = new List<Player>() { player1, player2, player3 };
            var winners = new List<Player>() { player2 };

            Assert.True(players.TrueForAll(player => PokerUtilities.IsOnePair(player.Hand.Cards)));

            Assert.Equal(winners, TieBreak.BreakOnePairTies(players));
        }

        [Fact]
        public void ReturnsOnePairWinnerWhenSingleTwoPairsPresentForWinner()
        {
            var player1 = new Player("Player1, 2D, 2H, 6S, 9S, JC");
            var player2 = new Player("Player2, 4H, 2S, 3H, AC, 4C");
            var player3 = new Player("Player3, QS, QD, 3D, 3C, KH");

            var players = new List<Player>() { player1, player2, player3 };
            var winners = new List<Player>() { player3 };

            Assert.True(players.TrueForAll(player => PokerUtilities.IsOnePair(player.Hand.Cards)));

            Assert.Equal(winners, TieBreak.BreakOnePairTies(players));
        }

        [Fact]
        public void ReturnsOnePairWinnerWhenSingleTwoPairsPresentForLoser()
        {
            var player1 = new Player("Player1, 2D, 2H, 6S, 9S, JC");
            var player2 = new Player("Player2, 4H, 3S, 3H, AC, 4C");
            var player3 = new Player("Player3, QS, QD, 3D, 7C, KH");

            var players = new List<Player>() { player1, player2, player3 };
            var winners = new List<Player>() { player3 };

            Assert.True(players.TrueForAll(player => PokerUtilities.IsOnePair(player.Hand.Cards)));

            Assert.Equal(winners, TieBreak.BreakOnePairTies(players));
        }

        [Fact]
        public void ReturnsOnePairWinnerWhenMultipleSameTwoPairsPresent()
        {
            var player1 = new Player("Player1, 2D, 2H, 6S, 9S, JC");
            var player2 = new Player("Player2, 4H, 3S, 3H, KC, 4C");
            var player3 = new Player("Player3, 4S, 4D, 3D, 3C, AH");

            var players = new List<Player>() { player1, player2, player3 };
            var winners = new List<Player>() { player3 };

            Assert.True(players.TrueForAll(player => PokerUtilities.IsOnePair(player.Hand.Cards)));

            Assert.Equal(winners, TieBreak.BreakOnePairTies(players));
        }

        [Fact]
        public void ReturnsOnePairWinnerWhenMultipleTwoPairsPresentAndWinnerHasOnePair()
        {
            var player1 = new Player("Player1, 4S, 4D, 3D, 3C, AH");
            var player2 = new Player("Player2, 4H, 3S, 3H, KC, 4C");
            var player3 = new Player("Player3, AD, AC, 6S, 9S, JC");

            var players = new List<Player>() { player1, player2, player3 };
            var winners = new List<Player>() { player3 };

            Assert.True(players.TrueForAll(player => PokerUtilities.IsOnePair(player.Hand.Cards)));

            Assert.Equal(winners, TieBreak.BreakOnePairTies(players));
        }

        [Fact]
        public void ReturnsOnePairWinnerWhenMultipleDifferentTwoPairsPresent()
        {
            var player1 = new Player("Player1, 2D, 2H, 6S, 9S, JC");
            var player2 = new Player("Player2, 4H, 3S, 3H, KC, 4C");
            var player3 = new Player("Player3, QS, QD, 3D, 3C, AH");

            var players = new List<Player>() { player1, player2, player3 };
            var winners = new List<Player>() { player3 };

            Assert.True(players.TrueForAll(player => PokerUtilities.IsOnePair(player.Hand.Cards)));

            Assert.Equal(winners, TieBreak.BreakOnePairTies(players));
        }

        [Fact]
        public void ReturnsMultipleOnePairWinners()
        {
            var player1 = new Player("Player1, 2D, 2H, 6S, 9S, JC");
            var player2 = new Player("Player2, 4H, 3S, 3H, AC, 4C");
            var player3 = new Player("Player3, 4S, 4D, 3D, 3C, AH");

            var players = new List<Player>() { player1, player2, player3 };
            var winners = new List<Player>() { player2, player3 };

            Assert.True(players.TrueForAll(player => PokerUtilities.IsOnePair(player.Hand.Cards)));

            Assert.Equal(winners, TieBreak.BreakOnePairTies(players));
        }
    }
}
