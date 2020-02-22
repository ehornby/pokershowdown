using System;
using System.Collections.Generic;
using System.Text;

namespace PokerShowdown.Shared
{
    public interface IGame
    {
        void ComparePlayerHands();
        void AddPlayer(string playerInput);
    }
}