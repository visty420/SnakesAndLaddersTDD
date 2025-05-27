using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;

namespace SnakesAndLadders.Core;

public class GameEngine
{
    public IReadOnlyList<Player> Players => _players.AsReadOnly();
    private readonly List<Player> _players;

    private readonly GameBoard _board;

    private readonly Dice _dice;

    private int _currentPlayerIndex = 0;

    public bool IsGameOver { get; private set; }
    public Player? Winner { get; private set; }

    public Player CurrentPlayer => _players[_currentPlayerIndex];

    public GameEngine(IEnumerable<string> playerNames, GameBoard board, Dice dice)
    {
        _players = playerNames.Select(name => new Player(name)).ToList();
        _board = board;
        _dice = dice;
    }

    public void PlayTurn()
    {
        if (IsGameOver)
        {
            return;
        }


        var currentPlayer = _players[_currentPlayerIndex];
        int steps = _dice.Roll();

        _board.MovePlayer(currentPlayer, steps);
        if (currentPlayer.Position == 100)
        {
            IsGameOver = true;
            Winner = currentPlayer;
            return;
        }
        _currentPlayerIndex = (_currentPlayerIndex + 1) % _players.Count;
    }
    public void AdvanceTurn()
    {
        _currentPlayerIndex = (_currentPlayerIndex + 1) % _players.Count;
    }
}