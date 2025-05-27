namespace SnakesAndLadders.Core;

public class GameBoard
{
    private const int FinalSquare = 100;
    private readonly Dictionary<int, int> _snakes;
    private readonly Dictionary<int, int> _ladders;

    public GameBoard(Dictionary<int, int>? snakes = null, Dictionary<int, int>? ladders = null)
    {
        _snakes = snakes ?? new Dictionary<int, int>();
        _ladders = ladders ?? new Dictionary<int, int>();
    }

    public void MovePlayer(Player player, int steps)
    {
        int target = player.Position + steps;
        if (target > FinalSquare)
        {
            target = FinalSquare;
        }
        Console.WriteLine($"Taget before snake/ladder: {target}");
        if (_ladders.ContainsKey(target))
        {
            Console.WriteLine("Ladder triggered!");
            target = _ladders[target];
        }
        else if (_snakes.ContainsKey(target))
        {
            Console.WriteLine("Snake triggered!");
            target = _snakes[target];
        }
        player.MoveTo(target);
         Console.WriteLine($"Moved to {target}");
    }
}