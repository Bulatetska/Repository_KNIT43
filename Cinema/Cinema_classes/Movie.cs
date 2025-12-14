namespace Cinema_classes
{
    public class Movie
    {
        public string Title { get; set; } = string.Empty;
        public int DurationMinutes { get; set; }
        public string Genre { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        public Movie(string title, int durationMinutes, string genre, string description)
        {
            
            DurationMinutes = durationMinutes;
            Title = string.Empty;
            Genre = string.Empty; 
            Description = string.Empty; 
        }

        public Movie() { }

        public override string ToString()
        {
            return $"{Title} ({Genre}) - {DurationMinutes} хв.";
        }
    }
}