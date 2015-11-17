namespace MyMovies.Models
{
    public class Movie
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public int GenreId { get; set; }

        public int Year { get; set; }

        public double Rating { get; set; }

        public string Cast { get; set; }
    }
}