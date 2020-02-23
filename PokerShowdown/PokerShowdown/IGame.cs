using System.Collections.Generic;

namespace PokerShowdown.Shared
{
    public interface IGame
    {
        List<Player> DetermineWinningPlayers();
        void AddPlayer(string playerInput);
        List<Player> TieBreakHands(List<Player> playersWithHighestRankedHand);
    }
}