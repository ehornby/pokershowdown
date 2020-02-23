using PokerShowdown.Shared;
using System.Collections.Generic;
using Xunit;
using FluentAssertions;

namespace PokerTests
{
    public class GameTests
    {
        [Fact]
        public void GameIntegrationTestWithFlushWinner()
        {
            IGame pokerGame = new Game();
            pokerGame.AddPlayer("Player1, 5C, 7C, 8C, TC, QC");
            pokerGame.AddPlayer("Player2, 6D, 6H, 6S, 5C, 8H");
            pokerGame.AddPlayer("Player3, 9C, 9D, AH, KH, 2S");

            var expectedWinningPlayers = new List<Player>();
            expectedWinningPlayers.Add(new Player("Player1, 5C, 7C, 8C, TC, QC"));

            var pokerGameWinners = pokerGame.DetermineWinningPlayers();

            pokerGameWinners.Should().BeEquivalentTo(expectedWinningPlayers);
        }

        [Fact]
        public void GameIntegrationTestWithThreeOfAKindWinner()
        {
            IGame pokerGame = new Game();
            pokerGame.AddPlayer("Player1, 4C, 7S, 8D, TC, 6C");
            pokerGame.AddPlayer("Player2, 6D, 6H, 6S, 5C, 8H");
            pokerGame.AddPlayer("Player3, 9C, 9D, AH, KH, 2S");

            var expectedWinningPlayers = new List<Player>();
            expectedWinningPlayers.Add(new Player("Player2, 6D, 6H, 6S, 5C, 8H"));

            var pokerGameWinners = pokerGame.DetermineWinningPlayers();

            pokerGameWinners.Should().BeEquivalentTo(expectedWinningPlayers);
        }

        [Fact]
        public void GameIntegrationTestWithThreeOfAKindWinnerWhenWinnerHasFourOfAKind()
        {
            IGame pokerGame = new Game();
            pokerGame.AddPlayer("Player1, 4C, 7S, 8D, TC, 6C");
            pokerGame.AddPlayer("Player2, 6D, 6H, 6S, 6C, 8H");
            pokerGame.AddPlayer("Player3, 9C, 9D, AH, KH, 2S");

            var expectedWinningPlayers = new List<Player>();
            expectedWinningPlayers.Add(new Player("Player2, 6D, 6H, 6S, 6C, 8H"));

            var pokerGameWinners = pokerGame.DetermineWinningPlayers();

            pokerGameWinners.Should().BeEquivalentTo(expectedWinningPlayers);
        }

        [Fact]
        public void GameIntegrationTestWithThreeOfAKindWinnerWhenWinnerHasAdditionalPair()
        {
            IGame pokerGame = new Game();
            pokerGame.AddPlayer("Player1, 4C, 7S, 8D, TC, 6C");
            pokerGame.AddPlayer("Player2, 6D, 6H, 6S, 8C, 8H");
            pokerGame.AddPlayer("Player3, 9C, 9D, AH, KH, 2S");

            var expectedWinningPlayers = new List<Player>();
            expectedWinningPlayers.Add(new Player("Player2, 6D, 6H, 6S, 8C, 8H"));

            var pokerGameWinners = pokerGame.DetermineWinningPlayers();

            pokerGameWinners.Should().BeEquivalentTo(expectedWinningPlayers);
        }

        [Fact]
        public void GameIntegrationTestWithOnePairWinner()
        {
            IGame pokerGame = new Game();
            pokerGame.AddPlayer("Player1, 4C, 7S, 8D, TC, 6C");
            pokerGame.AddPlayer("Player2, 6D, 2H, 6S, 5C, 8H");
            pokerGame.AddPlayer("Player3, TH, 9D, AH, KH, 2S");

            var expectedWinningPlayers = new List<Player>();
            expectedWinningPlayers.Add(new Player("Player2, 6D, 2H, 6S, 5C, 8H"));

            var pokerGameWinners = pokerGame.DetermineWinningPlayers();

            pokerGameWinners.Should().BeEquivalentTo(expectedWinningPlayers);
        }

        [Fact]
        public void GameIntegrationTestWithOnePairWinnerWhenWinnerHasTwoPair()
        {
            IGame pokerGame = new Game();
            pokerGame.AddPlayer("Player1, 4C, 7S, 8D, TC, 6C");
            pokerGame.AddPlayer("Player2, 6D, 2H, 6S, 5C, 5H");
            pokerGame.AddPlayer("Player3, TH, 9D, AH, KH, 2S");

            var expectedWinningPlayers = new List<Player>();
            expectedWinningPlayers.Add(new Player("Player2, 6D, 2H, 6S, 5C, 5H"));

            var pokerGameWinners = pokerGame.DetermineWinningPlayers();

            pokerGameWinners.Should().BeEquivalentTo(expectedWinningPlayers);
        }

        [Fact]
        public void GameIntegrationTestWithHighCardWinner()
        {
            IGame pokerGame = new Game();
            pokerGame.AddPlayer("Player1, 4C, 7S, 8D, TC, 6C");
            pokerGame.AddPlayer("Player2, 6D, 2H, 3S, 5C, 8H");
            pokerGame.AddPlayer("Player3, TH, 9D, AH, KH, 2S");

            var expectedWinningPlayers = new List<Player>();
            expectedWinningPlayers.Add(new Player("Player3, TH, 9D, AH, KH, 2S"));

            var pokerGameWinners = pokerGame.DetermineWinningPlayers();

            pokerGameWinners.Should().BeEquivalentTo(expectedWinningPlayers);
        }

        [Fact]
        public void GameIntegrationTestWithMultipleFlushWinners()
        {
            IGame pokerGame = new Game();
            pokerGame.AddPlayer("Player1, 5C, 7C, 8C, TC, QC");
            pokerGame.AddPlayer("Player2, 5D, 7D, 8D, TD, QD");
            pokerGame.AddPlayer("Player3, 9C, 9D, AH, KH, 2S");

            var expectedWinningPlayers = new List<Player>();
            expectedWinningPlayers.Add(new Player("Player1, 5C, 7C, 8C, TC, QC"));
            expectedWinningPlayers.Add(new Player("Player2, 5D, 7D, 8D, TD, QD"));

            var pokerGameWinners = pokerGame.DetermineWinningPlayers();

            pokerGameWinners.Should().BeEquivalentTo(expectedWinningPlayers);
        }

        [Fact]
        public void GameIntegrationTestWithMultipleOnePairWinners()
        {
            IGame pokerGame = new Game();
            pokerGame.AddPlayer("Player1, 6H, 2S, 6C, 5D, 8C");
            pokerGame.AddPlayer("Player2, 6D, 2H, 6S, 5C, 8H");
            pokerGame.AddPlayer("Player3, TH, 9D, AH, KH, 2D");

            var expectedWinningPlayers = new List<Player>();
            expectedWinningPlayers.Add(new Player("Player1, 6H, 2S, 6C, 5D, 8C"));
            expectedWinningPlayers.Add(new Player("Player2, 6D, 2H, 6S, 5C, 8H"));

            var pokerGameWinners = pokerGame.DetermineWinningPlayers();

            pokerGameWinners.Should().BeEquivalentTo(expectedWinningPlayers);
        }

        [Fact]
        public void GameIntegrationTestWithMultipleHighCardWinners()
        {
            IGame pokerGame = new Game();
            pokerGame.AddPlayer("Player1, 4C, 7S, 8D, TC, 6C");
            pokerGame.AddPlayer("Player2, TS, 9H, AC, KS, 2D");
            pokerGame.AddPlayer("Player3, TH, 9D, AH, KH, 2S");

            var expectedWinningPlayers = new List<Player>();
            expectedWinningPlayers.Add(new Player("Player2, TS, 9H, AC, KS, 2D"));
            expectedWinningPlayers.Add(new Player("Player3, TH, 9D, AH, KH, 2S"));

            var pokerGameWinners = pokerGame.DetermineWinningPlayers();

            pokerGameWinners.Should().BeEquivalentTo(expectedWinningPlayers);
        }
    }
}
