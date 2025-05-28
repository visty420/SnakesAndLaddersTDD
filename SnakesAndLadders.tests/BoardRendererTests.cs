using Xunit;
using SnakesAndLadders.Core;
using System.Collections.Generic;
using System;
using System.Security.Cryptography;

namespace SnakesAndLadders.tests;

public class BoardRendererTests
{
    [Fact]
    public void RenderBoard_Returns_Ascii_Art_With_Players()
    {
        var snakes = new Dictionary<int, int>();
        snakes.Add(17, 7);

        var ladders = new Dictionary<int, int>();
        ladders.Add(3, 22);

        var board = new GameBoard(snakes, ladders);

        var players = new List<Player>();
        Player p1 = new Player("Alice");
        Player p2 = new Player("Bob");
        players.Add(p1);
        players.Add(p2);

        players[0].MoveTo(1);
        players[1].MoveTo(3);

        var renderer = new BoardRenderer(board, players);
        var ascii = renderer.Renderer();

        Assert.Contains("1[A]", ascii);
        Assert.Contains("3[B]", ascii);
        Assert.Contains("17[S]", ascii);
        Assert.Contains("3[L]", ascii);
    }
}