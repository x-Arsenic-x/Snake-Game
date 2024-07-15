namespace Snake_Game.Models
{
    internal class Snake
    {
        public static int X { get; set; } = Map.WindowWidth / 2;
        public static int Y { get; set; } = Map.WindowHeight / 2;
        public static char[] DirectionChars { get; } = { '^', 'v', '<', '>' };
        public static Direction? Direction { get; set; } = null;
        public static Queue<(int x, int y)> SnakeCoordinates { get; set; } = new();
        public static ConsoleColor SnakeColor { get; } = ConsoleColor.Magenta;
    }
}
