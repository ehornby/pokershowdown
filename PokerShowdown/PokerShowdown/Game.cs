using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PokerShowdown.Shared
{
    public class Game : IGame
    {
        public List<Player> Players { get; private set; }
        public List<Player> WinningPlayers { get; private set; }
        public int NumberOfPlayers { get; }

        public Game(int numberOfPlayers)
        {
            NumberOfPlayers = numberOfPlayers;
        }

        public void ComparePlayerHands()
        {
            var winningHand = Players.Max(p => p.Hand.HandRank);
            WinningPlayers = Players.Where(p => p.Hand.HandRank == winningHand).ToList();
        }

        public void WriteWinnersToConsole()
        {
            var winningPlayersString = "";
            foreach (var player in WinningPlayers)
            {
                winningPlayersString += $"{player.Name}, ";
            }
            winningPlayersString = winningPlayersString.Substring(0, winningPlayersString.Length - 2);
            Console.WriteLine($"Winning players are: {winningPlayersString}");
        }

        public void CreatePlayerList()
        {
            Console.WriteLine($"Enter each player's name and cards in hand, separated by commas.");
            Console.WriteLine("Please use a letter 'T' to represent a card with rank 10.");
            Console.WriteLine("Example: \"Joe, 3H, 4H, 5H, 6H, TH\"");

            for (int i = 0; i < NumberOfPlayers; i++)
            {
                Console.WriteLine($"Player {i + 1}:");
                var playerInput = Console.ReadLine();
                Players.Add(new Player(playerInput));
            }
        }
    }
}
