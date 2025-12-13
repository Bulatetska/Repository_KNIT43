namespace Cinema_classes
{
    public class Movie
    {
        public string Title { get; set; }
        public int DurationMinutes { get; set; }
        public string Genre { get; set; }
        public string Description { get; set; }

        public Movie(string title, int durationMinutes, string genre, string description)
        {
            Title = title;
            DurationMinutes = durationMinutes;
            Genre = genre;
            Description = description;
        }

        public override string ToString()
        {
            return $"{Title} ({Genre}) - {DurationMinutes} хв.";
        }
    }
}