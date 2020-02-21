using PokerShowdown.Models;
using System;
using System.Linq;

namespace PokerShowdown.Shared
{
    public class Player
    {
        public string Name { get; }
        public Hand Hand { get; }

        public Player(string userInput)
        {
            var splitInput = userInput.Split(',', StringSplitOptions.RemoveEmptyEntries).ToList();
            Name = splitInput.First();

            splitInput.RemoveAt(0);
            for (int i = 0; i < splitInput.Count; i++)
            {
                splitInput[i] = splitInput[i].Trim();
            }
            Hand = new Hand(splitInput);
        }
    }
}
