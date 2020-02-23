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
        /// Compares hands from each player
        /// </summary>
        /// <returns>List<Player> of all winning players</returns>
        public List<Player> DetermineWinningPlayers()
        {
            var winningHand = Players.Max(p => p.Hand.HandRank);
            var playersWithHighestRankedHand = Players.Where(p => p.Hand.HandRank == winningHand).ToList();

            if (playersWithHighestRankedHand.Count == 1)
            {
                return playersWithHighestRankedHand;
            }
            
            return TieBreakHands(playersWithHighestRankedHand);
        }

        /// <summary>
        /// Adds a new Player to the Players property
        /// </summary>
        /// <param name="playerData">Player name and cards in the following format: "NAME, CARD, CARD, CARD, CARD, CARD"</param>
        public void AddPlayer(string playerData)
        {
            Players.Add(new Player(playerData));
        }

        /// <summary>
        /// Breaks ties when multiple players have the same hand rank
        /// </summary>
        /// <param name="playersWithSameHandRank">List<Player> of players with the highest ranked hand</param>
        /// <returns>List<Player> of winning players</returns>
        public List<Player> TieBreakHands(List<Player> playersWithSameHandRank)
        {
            var handTypeToTieBreak = playersWithSameHandRank
                .First()
                .Hand
                .HandRank;
            
            switch (handTypeToTieBreak)
            {
                case HandRank.Flush:
                    return TieBreak.BreakHighCardOrFlushTies(playersWithSameHandRank);
                case HandRank.ThreeOfAKind:
                    return new List<Player> { TieBreak.BreakThreeOfAKindTies(playersWithSameHandRank) };
                case HandRank.OnePair:
                    return TieBreak.BreakOnePairTies(playersWithSameHandRank);
                case HandRank.HighCard:
                    return TieBreak.BreakHighCardOrFlushTies(playersWithSameHandRank);
                default:
                    return new List<Player>();
            }
        }
    }
}
