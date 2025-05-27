using Xunit;
using SnakesAndLadders.Core;

namespace SnakesAndLadders.tests;

public class GameBoardTests
{
    [Fact]
    public void MovePlayer_Advances_Position_By_Steps()
    {
        var board = new GameBoard();
        var player = new Player("Bob");

        board.MovePlayer(player, 4);

        Assert.Equal(5, player.Position);
    }
}