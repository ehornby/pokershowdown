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
        public void ReturnsThreeOfAKindWinnerFromTwoPlayers()
        {
            var player1 = new Player("Player1, 3H, 3C, 3D, 6D, 8H");
            var player2 = new Player("Player2, 6C, 6D, 6S, 2C, 4H");

            var players = new List<Player>() { player1, player2 };
            var winner = player2;

            Assert.True(players.TrueForAll(player => PokerUtilities.IsThreeOfAKind(player.Hand.Cards)));

            Assert.Equal(winner, TieBreak.BreakThreeOfAKindTies(players));
        }

        [Fact]
        public void ReturnsThreeOfAKindWinnerFromThreePlayers()
        {
            var player1 = new Player("Player1, 3H, 3C, 3D, 6D, 8C");
            var player2 = new Player("Player3, 5H, 5C, 5D, 2H, KH");
            var player3 = new Player("Player4, 8S, 8D, 8H, KS, 5S");

            var players = new List<Player>() { player1, player2, player3 };
            var winner = player3;

            Assert.True(players.TrueForAll(player => PokerUtilities.IsThreeOfAKind(player.Hand.Cards)));

            Assert.Equal(winner, TieBreak.BreakThreeOfAKindTies(players));
        }

        [Fact]
        public void ReturnsThreeOfAKindWinnerFromFourPlayers()
        {
            var player1 = new Player("Player1, 3H, 3C, 3D, 6D, 8C");
            var player2 = new Player("Player2, 6C, 6D, 6S, 2C, 4H");
            var player3 = new Player("Player3, 8S, 8D, 8H, KS, 5S");
            var player4 = new Player("Player4, 5H, 5C, 5D, 2H, KH");

            var players = new List<Player>() { player1, player2, player3, player4 };
            var winner = player3;

            Assert.True(players.TrueForAll(player => PokerUtilities.IsThreeOfAKind(player.Hand.Cards)));

            Assert.Equal(winner, TieBreak.BreakThreeOfAKindTies(players));
        }
    }
}
