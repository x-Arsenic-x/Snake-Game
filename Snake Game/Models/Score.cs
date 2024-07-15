namespace Snake_Game.Models
{
    internal class Score
    {
        public static int ScoreAmount { get; set; } = 0;

        public static void RenderScore()
        {
            Console.ForegroundColor = Map.DefaultColor;
            Console.SetCursorPosition((Map.WindowWidth - $" Score: {ScoreAmount} ".Length) / 2, 0);
            Console.Write($" Score: {ScoreAmount} ");
            Console.ResetColor();
        }
    }
}
