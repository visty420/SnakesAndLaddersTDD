using Xunit;
using SnakesAndLadders.Core;

namespace SnakesAndLadders.tests;

public class PlayerTests
{
    [Fact]
    public void Player_Is_Initialized_With_Name_And_Position_One()
    {
        var player = new Player("Alex");

        Assert.Equal("Alex", player.Name);
        Assert.Equal(1, player.Position);
    }
}