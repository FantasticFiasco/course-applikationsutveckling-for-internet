using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;

namespace MyMovies.Dal
{
    public class MoviesContextInitializer : DropCreateDatabaseIfModelChanges<MoviesContext>
    {
        protected override void Seed(MoviesContext context)
        {
            AddMovie(
                context,
                "The Shawshank Redemption",
                1994,
                9.3,
                "Tim Robbins",
                "Morgan Freeman",
                "Bob Gunton",
                "William Sadler",
                "Clancy Brown");

            AddMovie(
                context,
                "The Godfather",
                1972,
                9.2,
                "Marlon Brando",
                "Al Pacino",
                "James Caan",
                "Richard S. Castellano",
                "Robert Duvall");

            AddMovie(
                context,
                "The Godfather: Part II",
                1974,
                9.0,
                "Al Pacino",
                "Robert Duvall",
                "Diane Keaton",
                "Robert De Niro",
                "John Cazale");

            AddMovie(
                context,
                "The Dark Knight",
                2008,
                9.0,
                "Christian Bale",
                "Heath Ledger",
                "Aaron Eckhart",
                "Michael Caine",
                "Maggie Gyllenhaal");

            AddMovie(
                context,
                "12 Angry Men",
                1957,
                8.9,
                "Martin Balsam",
                "John Fiedler",
                "Lee J. Cobb",
                "E.G. Marshall",
                "Jack Klugman");

            base.Seed(context);
        }

        private static void AddMovie(
            MoviesContext context,
            string title,
            int year,
            double rating,
            params string[] actorNames)
        {
            List<Actor> actors = actorNames
                .Select(actorName => CreateActor(context, actorName))
                .ToList();

            context.Movies.Add(new Movie
            {
                Title = title,
                Year = year,
                Rating = rating,
                Actors = new Collection<Actor>(actors)
            });
        }

        private static Actor CreateActor(MoviesContext context, string name)
        {
            Actor existingActor = context.Actors.FirstOrDefault(actor =>
                string.Compare(actor.Name, name, StringComparison.OrdinalIgnoreCase) == 0);

            if (existingActor != null)
                return existingActor;

            existingActor = context.Actors.Local.FirstOrDefault(actor =>
                string.Compare(actor.Name, name, StringComparison.OrdinalIgnoreCase) == 0);

            if (existingActor != null)
                return existingActor;

            return new Actor
            {
                Name = name
            };
        }
    }
}