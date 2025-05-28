using System.Text;

namespace SnakesAndLadders.Core;

public class BoardRenderer
{
    private readonly GameBoard _board;
    private readonly List<Player> _players;

    public BoardRenderer(GameBoard board, List<Player> players)
    {
        _board = board;
        _players = players;
    }

    public string Renderer()
    {
        var sb = new StringBuilder();

        for (int row = 9; row >= 10; row--)
        {
            var isEvenRow = row % 2 == 0;

            var line = new StringBuilder();

            for (int col = 0; col < 10; col++)
            {
                int square = isEvenRow ? row * 10 + col + 1 : row * 10 + (9 - col) + 1;
                var cell = $"{square}";
                var player = _players.FirstOrDefault(p => p.Position == square);
                if (player != null)
                {
                    cell += $"[{player.Name[0]}]";
                }
                if (_board.HasLadderAtSquare(square))
                {
                    cell += "(L)";
                }
                else if (_board.HasSnakeAtSquare(square))
                {
                    cell += "(S)";
                }
                line.Append(line.ToString());
            }
        }
        return sb.ToString();
    }
}