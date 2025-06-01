namespace SnakesAndLadders.Core;

public class GameLogger
{
    private readonly List<string> _entries = new();

    public void LogMove(string playerName, int roll, int from, int to, bool hitSnake, bool hitLadder)
    {
        string outcome = $"{playerName} rolled {roll}: {from} -> {to}";

        if (hitSnake)
        {
            outcome += "snake";
        }
        else if (hitLadder)
        {
            outcome += "ladder";
        }
        _entries.Add(outcome);
    }
    public List<string> GetLog()
    {
        return new List<string>(_entries);
    }
}