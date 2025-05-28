using SnakesAndLadders.Core;

var playing = true;

while (playing)
{
    Console.Clear();
    Console.WriteLine("====Welcome to Snakes and Ladders ====\n");

    Console.Write("Enter player 1's name <- no fighting on who player 1 is!");
    var p1 = Console.ReadLine()?.Trim() ?? "Player 1";

    Console.WriteLine("Enter player 2's name <- no shame in being player 2 :D.");
    var p2 = Console.ReadLine()?.Trim() ?? "Player 2;";

    var players = new List<string> { p1, p2 };

    var snakes = new Dictionary<int, int>();
    snakes.Add(17, 7);
    snakes.Add(62, 19);
    snakes.Add(87, 24);
    snakes.Add(99, 78);

    var ladders = new Dictionary<int, int>();
    ladders.Add(3, 22);
    ladders.Add(8, 30);
    ladders.Add(28, 84);
    ladders.Add(58, 77);

    var board = new GameBoard(snakes, ladders);
    var dice = new Dice();
    var engine = new GameEngine(players, board, dice);

    var renderer = new BoardRenderer(board, engine.Players.ToList());

    Console.WriteLine("\nStarting game!\nPress any key to roll :).");
    Console.ReadKey(true);
    Console.ReadLine();

    while (!engine.IsGameOver)
    {
        var currentPlayer = engine.CurrentPlayer;
        Console.WriteLine($"\n{currentPlayer.Name}'s turn. Current position:{currentPlayer.Position}");
        Console.WriteLine("\nPress any key to roll the dice!");
        Console.ReadKey();

        Console.Clear();
        Console.WriteLine(renderer.Renderer());
        Console.WriteLine($"\n{currentPlayer.Name}'s turn. Current position: {currentPlayer.Position}");
        Console.WriteLine("Press enter to roll the dice...");
        Console.ReadLine();
        
        var roll = dice.Roll();
        Console.WriteLine($"{currentPlayer.Name} rolled a {roll}.");

        int before = currentPlayer.Position;
        board.MovePlayer(currentPlayer, roll);
        int after = currentPlayer.Position;

        if (after > before)
        {
            Console.WriteLine($"{currentPlayer.Name} moved to {after}.");
        }
        else if (after < before)
        {
            Console.WriteLine($"{currentPlayer.Name} hit a snake! Slid down to {after}.");
        }
        else
        {
            Console.WriteLine($"{currentPlayer.Name} stayed on square {after}.");
        }

        if (after == 100)
        {
            Console.WriteLine($"\n*** {currentPlayer.Name} wins! ***");
            break;
        }
        engine.AdvanceTurn();
    }
    Console.WriteLine("\nPlay again? (y/n): ");
    playing = Console.ReadLine()?.ToLower() == "y";

}