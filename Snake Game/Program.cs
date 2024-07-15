using Snake_Game.Models;
using System.Text;

try
{
    int speed;

    while (true)
    {
        Console.Clear();

        Console.SetCursorPosition(0, 0);
        Console.Write("Please select speed [1], [2] (default), or [3]: ");

        if (!int.TryParse(Console.ReadLine(), out speed) || speed < 1 || speed > 3)
        {
            Console.WriteLine("Invalid Input. Try Again...");
        }
        else
        {
            break;
        }
    }

    Map.Speed = speed;
    Map.Velocity = Map.Velocities[Map.Speed - 1];
    Map.Sleep = TimeSpan.FromMilliseconds(Map.Velocity);

    Console.Clear();
    Console.CursorVisible = false;
    Console.OutputEncoding = Encoding.UTF8;

    Score.RenderScore();
    Food.RenderFood();

    Snake.SnakeCoordinates.Enqueue((Snake.X, Snake.Y));
    Map.MapTiles[Snake.X, Snake.Y] = Tile.Snake;

    Console.ForegroundColor = Snake.SnakeColor;
    Console.SetCursorPosition(Snake.X, Snake.Y);
    Console.Write('@');
    Console.ResetColor();

    while (!Snake.Direction.HasValue && !Map.CloseRequested)
    {
        Map.GetDirection();
    }
    while (!Map.CloseRequested)
    {
        if (Console.WindowWidth != Map.WindowWidth || Console.WindowHeight != Map.WindowHeight)
        {
            Console.Clear();

            var message = $"The console size has changed, the snake game is over.";

            Console.ForegroundColor = Map.ErrorColor;
            Console.SetCursorPosition((Console.WindowWidth - message.Length) / 2, Console.WindowHeight / 2);
            Console.Write(message);
            Console.ResetColor();

            Console.ReadKey();
            return;
        }
        switch (Snake.Direction)
        {
            case Direction.Up:
                Snake.Y--;
                break;

            case Direction.Down:
                Snake.Y++;
                break;

            case Direction.Left:
                Snake.X--;
                break;

            case Direction.Right:
                Snake.X++;
                break;
        }
        if (Snake.Y == 0 || Snake.X == 0 || Snake.X >= Map.WindowWidth || Snake.Y >= Map.WindowHeight)
        {
            switch (Snake.Direction)
            {
                case Direction.Up:
                    Snake.Y = Map.WindowHeight - 1;
                    break;

                case Direction.Down:
                    Snake.Y = 1;
                    break;

                case Direction.Left:
                    Snake.X = Map.WindowWidth - 1;
                    break;

                case Direction.Right:
                    Snake.X = 1;
                    break;
            }
        }
        if (Map.MapTiles[Snake.X, Snake.Y] is Tile.Snake)
        {
            Console.Clear();

            var message = $"Game over, press any key to exit.";

            Console.ForegroundColor = Map.ErrorColor;
            Console.SetCursorPosition((Map.WindowWidth - message.Length) / 2, Map.WindowHeight / 2);
            Console.Write(message);
            Console.ResetColor();

            Console.ReadKey();
            Console.Clear();
            break;
        }

        Console.ForegroundColor = Snake.SnakeColor;
        Console.SetCursorPosition(Snake.X, Snake.Y);
        Console.Write(Snake.DirectionChars[(int)Snake.Direction!]);
        Console.ResetColor();
        Snake.SnakeCoordinates.Enqueue((Snake.X, Snake.Y));

        if (Map.MapTiles[Snake.X, Snake.Y] is Tile.Food)
        {
            Score.ScoreAmount += 10;
            Score.RenderScore();
            Food.RenderFood();
        }
        else
        {
            (int x, int y) = Snake.SnakeCoordinates.Dequeue();
            Map.MapTiles[x, y] = Tile.Open;

            Console.SetCursorPosition(x, y);
            Console.Write(' ');
        }

        Map.MapTiles[Snake.X, Snake.Y] = Tile.Snake;

        if (Console.KeyAvailable)
        {
            Map.GetDirection();
        }

        Thread.Sleep(Map.Sleep);
    }
}
catch (Exception exception)
{
    Console.ForegroundColor = Map.ErrorColor;
    Console.SetCursorPosition((Map.WindowWidth - exception.Message.Length) / 2, 0);
    Console.Write(exception.Message);
    Console.ResetColor();

    Console.ReadKey();
    Console.Clear();
}