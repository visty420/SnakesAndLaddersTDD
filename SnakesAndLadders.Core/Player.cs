namespace SnakesAndLadders.Core;

public class Player
{
    public string? Name { get; }
    public int Position { get; private set; }

    public Player(string name)
    {
        Name = name;
        Position = 1;
    }

    public void MoveTo(int newPosition)
    {
        Position = newPosition;
    }
}