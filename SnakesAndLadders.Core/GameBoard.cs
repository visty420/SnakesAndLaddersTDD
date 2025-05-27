namespace SnakesAndLadders.Core;

public class GameBoard
{
    private const int FinalSquare = 100;

    public void MovePlayer(Player player, int steps)
    {
        int target = player.Position + steps;

        if (target > FinalSquare)
        {
            target = FinalSquare;
        }
        player.MoveTo(target);
    }

}