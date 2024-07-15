namespace Snake_Game.Models
{
    internal class Food
    {
        public static List<(int X, int Y)> PossibleCoordinates { get; set; } = [];
        public static ConsoleColor FoodColor { get; } = ConsoleColor.Yellow;

        public static void RenderFood()
        {
            for (int i = 4; i < Map.WindowWidth - 3; i++)
            {
                for (int j = 4; j < Map.WindowHeight - 3; j++)
                {
                    if (Map.MapTiles[i, j] is Tile.Open)
                    {
                        PossibleCoordinates.Add((i, j));
                    }
                }
            }

            int index = Random.Shared.Next(PossibleCoordinates.Count);

            (int x, int y) = PossibleCoordinates[index];
            Map.MapTiles[x, y] = Tile.Food;

            Console.ForegroundColor = FoodColor;
            Console.SetCursorPosition(x, y);
            Console.Write('+');
            Console.ResetColor();
        }
    }
}
