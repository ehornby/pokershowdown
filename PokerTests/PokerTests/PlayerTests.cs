using PokerShowdown.Shared;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace PokerTests
{
    public class PlayerTests
    {
        [Fact]
        public void CreatesPlayerFromInputWithSingleName()
        {
            var input = "Phil, 6C, 7D, AS, 9C, TC";
            var singleNamePlayer = new Player(input);
            Assert.Equal("Phil", singleNamePlayer.Name);
        }

        [Fact]
        public void CreatesPlayerFromInputWithMultipleName()
        {
            var input = "Tom Dwan, 8S, AC, 2S, 9H, QH";
            var multipleNamePlayer = new Player(input);
            Assert.Equal("Tom Dwan", multipleNamePlayer.Name);
        }
    }
}
