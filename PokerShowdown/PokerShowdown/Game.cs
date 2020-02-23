using System.Collections.Generic;
using System.Linq;
using PokerShowdown.Shared.Constants;

namespace PokerShowdown.Shared
{
    public class Game : IGame
    {
        public List<Player> Players { get; private set; }

        public Game()
        {
            Players = new List<Player>();
        }

        /// <summary>
        /// Compares Hands from each Player and sets WinningPlayers property
        /// </summary>
        public List<Player> DetermineWinningPlayers()
        {
            var winningHand = Players.Max(p => p.Hand.HandRank);
            var winningPlayers = new List<Player>();
            var playersWithHighestRankedHand = Players.Where(p => p.Hand.HandRank == winningHand).ToList();

            if (playersWithHighestRankedHand.Count == 1)
            {
                winningPlayers = playersWithHighestRankedHand;
            }
            else
            {
                winningPlayers = TieBreakHands(playersWithHighestRankedHand);
            }

            return winningPlayers;
        }

        /// <summary>
        /// Adds a new Player to the Players property
        /// </summary>
        /// <param name="playerData">Player name and cards in the following format: "NAME, CARD, CARD, CARD, CARD, CARD"</param>
        public void AddPlayer(string playerData)
        {
            Players.Add(new Player(playerData));
        }

        public List<Player> TieBreakHands(List<Player> playersWithHighestRankedHand)
        {
            var handTypeToTieBreak = playersWithHighestRankedHand.First().Hand.HandRank;
            
            switch (handTypeToTieBreak)
            {
                case HandRank.Flush:
                    return TieBreak.BreakHighCardOrFlushTies(playersWithHighestRankedHand);
                case HandRank.ThreeOfAKind:
                    return new List<Player> { TieBreak.BreakThreeOfAKindTies(playersWithHighestRankedHand) };
                case HandRank.OnePair:
                    return TieBreak.BreakOnePairTies(playersWithHighestRankedHand);
                case HandRank.HighCard:
                    return TieBreak.BreakHighCardOrFlushTies(playersWithHighestRankedHand);
                default:
                    return new List<Player>();
            }
        }
    }
}
