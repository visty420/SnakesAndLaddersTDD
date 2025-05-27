using System.Collections.Generic;
using System.Linq;

namespace SnakesAndLadders.Core;

public class GameEngine
{
    public IReadOnlyList<Player> Players => _players.AsReadOnly();
    private readonly List<Player> _players;

    private readonly GameBoard _board;

    private readonly Dice _dice;

    public GameEngine(IEnumerable<string> playerNames, GameBoard board, Dice dice)
    {
        _players = playerNames.Select(name => new Player(name)).ToList();
        _board = board;
        _dice = dice;
    }
}