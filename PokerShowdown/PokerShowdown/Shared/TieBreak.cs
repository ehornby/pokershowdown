using System.Collections.Generic;
using System.Linq;
using PokerShowdown.Shared.Constants;

namespace PokerShowdown.Shared
{
    public static class TieBreak
    {
        /// <summary>
        /// Breaks ties when multiple players have a HandRank of HighCard or Flush
        /// </summary>
        /// <param name="players">List of players whose hands require tiebreaking</param>
        /// <returns>List<Player> containing all players with the winning hand</returns>
        public static List<Player> BreakHighCardOrFlushTies(List<Player> players)
        {
            foreach (var player in players)
            {
                player.Hand.Cards.Sort((a, b) => b.Rank.CompareTo(a.Rank));
            }

            for (int i = 0; i < Constants.Constants.HAND_SIZE; i++)
            {
                var highestCardRankAmongAllPlayers = players.Max(player => player.Hand.Cards.Skip(i).First().Rank);
                var playersHoldingHighestCardRank = players.Where(player => player.Hand.Cards.Skip(i).First().Rank == highestCardRankAmongAllPlayers);

                var isLastCard = i == Constants.Constants.HAND_SIZE - 1;

                if (playersHoldingHighestCardRank.Count() == 1 || isLastCard)
                {
                    return playersHoldingHighestCardRank.ToList();
                }
            }

            return new List<Player>();
        }

        /// <summary>
        /// Breaks ties when multiple players have a HandRank of ThreeOfAKind
        /// </summary>
        /// <param name="players">List of players whose hands require tiebreaking</param>
        /// <returns>Player object representing the winning player</returns>
        public static Player BreakThreeOfAKindTies(List<Player> players)
        {
            var highestThreeOfAKindRank = CardRank.None;
            var playersHoldingHighestThreeOfAKind = new List<Player>();
            var winningPlayer = new Player();

            foreach (var player in players)
            {
                var cardsGroupedByRank = player.Hand.Cards.GroupBy(c => c.Rank);
                var threeOfAKindGroup = cardsGroupedByRank.Where(g => g.Count() >= 3);
                var threeOfAKindRank = threeOfAKindGroup.First().First().Rank;

                if (threeOfAKindRank > highestThreeOfAKindRank)
                {
                    highestThreeOfAKindRank = threeOfAKindRank;
                    winningPlayer = player;
                }
            }

            return winningPlayer;
        }

        /// <summary>
        /// Breaks ties when multiple players have a HandRank of OnePair
        /// </summary>
        /// <param name="players">List of players whose hands require tiebreaking</param>
        /// <returns>List<Player> containing all players with the winning hand</returns>
        public static List<Player> BreakOnePairTies(List<Player> players)
        {
            var highestPairAmongAllPlayers = CardRank.None;
            var playersWithHighestPair = new List<Player>();

            foreach (var player in players)
            {
                var cardsGroupedByRank = player.Hand.Cards.GroupBy(c => c.Rank);
                var pairGroupsSortedByDescendingRank = cardsGroupedByRank.Where(g => g.Count() == 2).OrderByDescending(g => g.Key);
                var highestPairRank = pairGroupsSortedByDescendingRank.First().First().Rank;

                if (highestPairRank > highestPairAmongAllPlayers)
                {
                    highestPairAmongAllPlayers = highestPairRank;
                    playersWithHighestPair.Clear();
                    playersWithHighestPair.Add(player);
                }
                else if (highestPairRank == highestPairAmongAllPlayers)
                {
                    playersWithHighestPair.Add(player);
                }
            }
                
            if (playersWithHighestPair.Count == 1)
            {
                return playersWithHighestPair.ToList();
            }
            else
            {
                var playersWithHighestPairAndBestKickers = BreakHighCardOrFlushTies(playersWithHighestPair);

                return playersWithHighestPairAndBestKickers.ToList();
            }
        }
    }
}



