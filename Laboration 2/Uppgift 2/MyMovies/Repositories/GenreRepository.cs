using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using MyMovies.Models;

namespace MyMovies.Repositories
{
    public class GenreRepository : IRepository<Genre>
    {
        public void Add(Genre entity)
        {
            using (SqlCommand command = CommandFactory.Create())
            {
                command.CommandText = "INSERT INTO Genres (Id, Name) VALUES (@id, @name)";
                command.Parameters.AddWithValue("@id", entity.Id);
                command.Parameters.AddWithValue("@name", entity.Name);

                command.ExecuteNonQuery();
            }
        }

        public Genre Find(int id)
        {
            using (SqlCommand command = CommandFactory.Create())
            {
                command.CommandText = "SELECT * FROM Genres WHERE Id=@id";
                command.Parameters.AddWithValue("@id", id);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    return reader.Read() ? Map(reader) : null;
                }
            }
        }

        public IEnumerable<Genre> Get()
        {
            using (SqlCommand command = CommandFactory.Create())
            {
                command.CommandText = "SELECT * FROM Genres";

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    var genre = new List<Genre>();

                    while (reader.Read())
                    {
                        genre.Add(Map(reader));
                    }

                    return genre;
                }
            }
        }

        public void Edit(Genre entity)
        {
            using (SqlCommand command = CommandFactory.Create())
            {
                command.CommandText = "UPDATE Genres SET Name=@name WHERE Id=@id";
                command.Parameters.AddWithValue("@name", entity.Name);
                command.Parameters.AddWithValue("@id", entity.Id);

                command.ExecuteNonQuery();
            }
        }

        public void Remove(Genre entity)
        {
            using (SqlCommand command = CommandFactory.Create())
            {
                command.CommandText = "DELETE FROM Genres WHERE Id=@id";
                command.Parameters.AddWithValue("@id", entity.Id);

                command.ExecuteNonQuery();
            }
        }

        private static Genre Map(IDataRecord reader)
        {
            return new Genre
            {
                Id = (int)reader["Id"],
                Name = (string)reader["Name"]
            };
        }
    }
}