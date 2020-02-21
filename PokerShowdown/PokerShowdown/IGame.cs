using System;
using System.Collections.Generic;
using System.Text;

namespace PokerShowdown.Shared
{
    interface IGame
    {
        void ComparePlayerHands();
        void WriteWinnersToConsole();
        void CreatePlayerList();
    }
}