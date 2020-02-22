using PokerShowdown.Models;
using System;
using System.Linq;

namespace PokerShowdown.Shared
{
    public class Player
    {
        public string Name { get; }
        public Hand Hand { get; private set; }

        public Player() { }

        /// <summary>
        /// Creates a new Player object
        /// </summary>
        /// <param name="playerData">Player name and cards in the following format: "NAME, CARD, CARD, CARD, CARD, CARD"</param>
        public Player(string playerData)
        {
            var splitPlayerData = playerData
                .Split(',', StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            Name = splitPlayerData.First();

            var rawCardData = splitPlayerData.Skip(1).ToList();

            for (int i = 0; i < rawCardData.Count; i++)
            {
                rawCardData[i] = rawCardData[i].Trim();
            }

            Hand = new Hand(rawCardData);
        }
    }
}
