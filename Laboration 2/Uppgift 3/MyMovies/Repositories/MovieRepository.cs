using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using MyMovies.Models;

namespace MyMovies.Repositories
{
    public class MovieRepository : IRepository<Movie>
    {
        public void Add(Movie entity)
        {
            using (SqlCommand command = CommandFactory.Create())
            {
                command.CommandText = "INSERT INTO Movies (Title, GenreId, Year, Rating, Cast) VALUES (@title, @genreId, @year, @rating, @cast)";
                command.Parameters.AddWithValue("@title", entity.Title);
                command.Parameters.AddWithValue("@genreId", entity.GenreId);
                command.Parameters.AddWithValue("@year", entity.Year);
                command.Parameters.AddWithValue("@rating", entity.Rating);
                command.Parameters.AddWithValue("@cast", entity.Cast);

                command.ExecuteNonQuery();
            }
        }

        public Movie Find(int id)
        {
            using (SqlCommand command = CommandFactory.Create())
            {
                command.CommandText = "SELECT * FROM Movies WHERE Id=@id";
                command.Parameters.AddWithValue("@id", id);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    return reader.Read() ? Map(reader) : null;
                }
            }
        }

        public IEnumerable<Movie> Get()
        {
            using (SqlCommand command = CommandFactory.Create())
            {
                command.CommandText = "SELECT * FROM Movies";

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    var movies = new List<Movie>();

                    while (reader.Read())
                    {
                        movies.Add(Map(reader));
                    }

                    return movies;
                }
            }
        }

        public IEnumerable<Movie> Get(int genreId)
        {
            using (SqlCommand command = CommandFactory.Create())
            {
                command.CommandText = "SELECT * FROM Movies WHERE GenreId=@genreId";
                command.Parameters.AddWithValue("@genreId", genreId);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    var movies = new List<Movie>();

                    while (reader.Read())
                    {
                        movies.Add(Map(reader));
                    }

                    return movies;
                }
            }
        }

        public void Edit(Movie entity)
        {
            using (SqlCommand command = CommandFactory.Create())
            {
                command.CommandText = "UPDATE Movies SET Title=@title,GenreId=@genreId,Year=@year,Rating=@rating,Cast=@cast WHERE Id=@id";
                command.Parameters.AddWithValue("@title", entity.Title);
                command.Parameters.AddWithValue("@genreId", entity.GenreId);
                command.Parameters.AddWithValue("@year", entity.Year);
                command.Parameters.AddWithValue("@rating", entity.Rating);
                command.Parameters.AddWithValue("@cast", entity.Cast);
                command.Parameters.AddWithValue("@id", entity.Id);

                command.ExecuteNonQuery();
            }
        }

        public void Remove(Movie entity)
        {
            using (SqlCommand command = CommandFactory.Create())
            {
                command.CommandText = "DELETE FROM Movies WHERE Id=@id";
                command.Parameters.AddWithValue("@id", entity.Id);

                command.ExecuteNonQuery();
            }
        }

        private static Movie Map(IDataRecord reader)
        {
            return new Movie
            {
                Id = (int)reader["Id"],
                Title = (string)reader["Title"],
                GenreId = (int)reader["GenreId"],
                Year = (int)reader["Year"],
                Rating = (double)reader["Rating"],
                Cast = (string)reader["Cast"]
            };
        }
    }
}