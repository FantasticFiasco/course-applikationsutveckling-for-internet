using System;
using System.Data.Entity;
using System.Linq;

namespace MyMovies.Dal
{
    public class MoviesContextInitializer : DropCreateDatabaseIfModelChanges<MoviesContext>
    {
        protected override void Seed(MoviesContext context)
        {
            AddGenre(context, "Action");
            AddGenre(context, "Animation");
            AddGenre(context, "Biography");
            AddGenre(context, "Comedy");
            AddGenre(context, "Crime");
            AddGenre(context, "Drama");
            AddGenre(context, "Horror");
            AddGenre(context, "Mystery");
            AddGenre(context, "Romance");
            AddGenre(context, "Sci-Fi");
            AddGenre(context, "War");

            AddMovie(
                context,
                "The Shawshank Redemption",
                1994,
                9.3,
                "Drama",
                "Tim Robbins, Morgan Freeman, Bob Gunton, William Sadler & Clancy Brown");

            AddMovie(
                context,
                "The Godfather",
                1972,
                9.2,
                "Drama",
                "Marlon Brando, Al Pacino, James Caan, Richard S. Castellano & Robert Duvall");

            AddMovie(
                context,
                "The Godfather: Part II",
                1974,
                9.0,
                "Drama",
                "Al Pacino, Robert Duvall, Diane Keaton, Robert De Niro & John Cazale");

            AddMovie(
                context,
                "The Dark Knight",
                2008,
                9.0,
                "Action",
                "Christian Bale, Heath Ledger, Aaron Eckhart, Michael Caine, & Maggie Gyllenhaal");

            AddMovie(
                context,
                "12 Angry Men",
                1957,
                8.9,
                "Drama",
                "Martin Balsam, John Fiedler, Lee J. Cobb, E.G. Marshall & Jack Klugman");

            AddMovie(
                context,
                "Schindler's List",
                1993,
                8.9,
                "Biography",
                "Oskar Schindler, Itzhak Stern, Amon Goeth, Emilie Schindler & Poldek Pfefferberg");

            base.Seed(context);
        }

        private static Genre AddGenre(MoviesContext context, string name)
        {
            Genre genre = context.Genre.FirstOrDefault(existingGenre =>
                string.Compare(existingGenre.Name, name, StringComparison.OrdinalIgnoreCase) == 0);

            if (genre != null)
                return genre;

            genre = context.Genre.Local.FirstOrDefault(existingGenre =>
                string.Compare(existingGenre.Name, name, StringComparison.OrdinalIgnoreCase) == 0);

            if (genre != null)
                return genre;

            return context.Genre.Add(new Genre { Name = name });
        }

        private static void AddMovie(
            MoviesContext context,
            string title,
            int year,
            double rating,
            string genre,
            string cast)
        {
            context.Movies.Add(new Movie
            {
                Title = title,
                Year = year,
                Rating = rating,
                Genre = AddGenre(context, genre),
                Cast = cast
            });
        }
    }
}