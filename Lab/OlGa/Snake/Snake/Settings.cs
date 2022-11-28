namespace OlGa
{
    public enum Direction
    {
        Up,
        Down,
        Left,
        Right
    }

    class Settings
    {
        
        public static int width { get; set; }
        public static int height { get; set; }
        
        public static int speed { get; set; }
        
        public static int score { get; set; }
        
        public static int points { get; set; }
        public static bool gameOver { get; set; }
        public static int duration { get; set; }
        public static Direction direction { get; set; }

        public Settings()
        {
            duration = 0;
            width = 12;
            height = 12;
            speed = 8;
            score = 0;
            points = 10;
            gameOver = false;
            direction = Direction.Right;
        }
    }
}
