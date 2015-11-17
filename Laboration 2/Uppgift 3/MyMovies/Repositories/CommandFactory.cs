using System.Configuration;
using System.Data.SqlClient;

namespace MyMovies.Repositories
{
    public static class CommandFactory
    {
        private static readonly string ConnectionString;

        static CommandFactory()
        {
            ConnectionString = ConfigurationManager.ConnectionStrings["Movies"].ConnectionString;
        }

        public static SqlCommand Create()
        {
            var connection = new SqlConnection(ConnectionString);
            
            var command = new SqlCommand(null, connection);
            command.Disposed += (_, __) => connection.Dispose();

            connection.Open();

            return command;
        }
    }
}