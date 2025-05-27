namespace SnakesAndLadders.Core;

public class GameBoard
{
    private const int FinalSquare = 100;
    private readonly Dictionary<int, int> _snakes;
    private readonly Dictionary<int, int> _ladders;

    public GameBoard(Dictionary<int, int>? snakes = null, Dictionary<int, int>? ladders = null)
    {
        _snakes = snakes ?? new();
        _ladders = ladders ?? new();
    }

    public void MovePlayer(Player player, int steps)
    {
        int target = player.Position + steps;
        if (target > FinalSquare)
        {
            target = FinalSquare;
        }
        player.MoveTo(target);
        if (_ladders.ContainsKey(target))
        {
            target = _ladders[target];
        }
        else if (_snakes.ContainsKey(target))
        {
            target = _snakes[target];
        }
    }
}