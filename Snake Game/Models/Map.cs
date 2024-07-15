namespace Snake_Game.Models
{
    internal class Map
    {
        public static ConsoleColor DefaultColor { get; } = ConsoleColor.Cyan;
        public static ConsoleColor ErrorColor { get; } = ConsoleColor.Red;
        public static bool CloseRequested { get; set; } = false;
        public static int WindowWidth { get; } = Console.WindowWidth;
        public static int WindowHeight { get; } = Console.WindowHeight;
        public static Tile[,] MapTiles { get; set; } = new Tile[WindowWidth, WindowHeight];
        public static int Speed { get; set; } = 2;
        public static int[] Velocities { get; } = { 100, 70, 50 };
        public static int Velocity { get; set; } = 0;
        public static TimeSpan Sleep { get; set; } = TimeSpan.Zero;

        public static void GetDirection()
        {
            switch (Console.ReadKey(true).Key)
            {
                case ConsoleKey.UpArrow:
                case ConsoleKey.W:
                    Snake.Direction = Direction.Up;
                    break;

                case ConsoleKey.DownArrow:
                case ConsoleKey.S:
                    Snake.Direction = Direction.Down;
                    break;

                case ConsoleKey.LeftArrow:
                case ConsoleKey.A:
                    Snake.Direction = Direction.Left;
                    break;

                case ConsoleKey.RightArrow:
                case ConsoleKey.D:
                    Snake.Direction = Direction.Right;
                    break;

                case ConsoleKey.Escape:
                    CloseRequested = true;
                    break;
            }
        }
    }
}
