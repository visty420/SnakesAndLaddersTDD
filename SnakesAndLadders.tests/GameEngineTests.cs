using Xunit;
using SnakesAndLadders.Core;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;

namespace SnakesAndLadders.tests;

public class GameEngineTests {
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
}