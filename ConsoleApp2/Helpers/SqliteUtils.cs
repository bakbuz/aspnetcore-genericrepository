using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;
using System.IO;

namespace ConsoleApp2.Helpers
{
    public static class SqliteUtils
    {
        public static DbConnection GetSqliteConnection(string databaseName)
        {
            var connectionStringBuilder = new SqliteConnectionStringBuilder { DataSource = databaseName };
            var connectionString = connectionStringBuilder.ToString();
            var connection = new SqliteConnection(connectionString);
            return connection;
        }

        public static void CreateDatabaseIfNotExists(DbContext context, string databaseName)
        {
            if (!File.Exists(databaseName))
            {
                context.Database.EnsureCreated();
                //context.Dispose();
            }
        }
    }
}
