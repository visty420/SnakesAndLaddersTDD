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

    [Fact]
    public void Player_Lands_On_Ladder_And_Is_Moved_Up()
    {
        var ladders = new Dictionary<int, int>();
        ladders.Add(3, 22);

        var board = new GameBoard(snakes: null, ladders: ladders);
        var player = new Player("Lana");

        board.MovePlayer(player, 2);

        Assert.Equal(22, player.Position);
    }
}