using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Dapper;

namespace EventOrganizer.Web.DAL
{
    public abstract class BaseRepository
    {
        private readonly string _connectionString;

        protected BaseRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        protected static void SetIdentity<T>(IDbConnection connection, Action<T> setId)
        {
            dynamic identity = connection.Query("SELECT @@IDENTITY AS Id").Single();
            var newId = (T)identity.Id;

            setId(newId);
        }

        protected IDbConnection OpenConnection()
        {
            IDbConnection connection = new SqlConnection(_connectionString);
            connection.Open();

            return connection;
        }
    }
}