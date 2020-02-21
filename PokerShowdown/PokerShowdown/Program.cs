using PokerShowdown.Shared;
using System;

namespace PokerShowdown
{
    class Program
    {
        public static void Main()
        {
            var numberOfPlayers = GetNumberOfPlayers();
            var currentGame = new Game(numberOfPlayers);
            currentGame.CreatePlayerList();
            currentGame.ComparePlayerHands();
            currentGame.WriteWinnersToConsole();
        }

        static int GetNumberOfPlayers()
        {
            Console.WriteLine("Welcome! How many players are in the game?");
            var playersInGame = Int32.Parse(Console.ReadLine());
            return playersInGame;
        }
    }
}
