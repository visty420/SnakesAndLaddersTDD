using Xunit;
using SnakesAndLadders.Core;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;

namespace SnakesAndLadders.tests;

public class GameEngineTests
{
    [Fact]
    public void GameEngine_Initilaizes_With_Two_Players()
    {
        var playerNames = new List<string>();
        playerNames.Add("Alice");
        playerNames.Add("Bob");

        var board = new GameBoard();
        var dice = new Dice();

        var engine = new GameEngine(playerNames, board, dice);

        var players = engine.Players.ToList();

        Assert.Equal(2, players.Count);
        Assert.Equal("Alice", players[0].Name);
        Assert.Equal("Bob", players[1].Name);
    }

    [Fact]
    public void PlayTurn_Moves_Current_Player_By_Dice_Roll()
    {
        var playerNames = new List<string>();
        playerNames.Add("Alice");
        playerNames.Add("Bob");

        var fakeDice = new FakeDice(4);
        var board = new GameBoard();
        var engine = new GameEngine(playerNames, board, fakeDice);

        engine.PlayTurn();

        var currentPlayer = engine.Players[0];
        Assert.Equal(5, currentPlayer.Position);
    }

    [Fact]
    public void Player_Wins_When_Reaching_Final_Square()
    {
        var playerNames = new List<string>();
        playerNames.Add("Alice");

        var fakeDice = new FakeDice(4);
        var board = new GameBoard();

        var engine = new GameEngine(playerNames, board, fakeDice);

        var player = engine.Players[0];
        player.MoveTo(96);

        engine.PlayTurn();

        Assert.True(engine.IsGameOver);
        Assert.Equal("Alice", engine.Winner?.Name);
    }
}