using ConsoleApp1.Helpers;
using ConsoleApp1.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Data.Common;

namespace ConsoleApp1
{
    public static class Startup
    {
        const string DATABASE_NAME = "perf.sqlite";
        static DbConnection SqliteConnection => SqliteUtils.GetSqliteConnection(DATABASE_NAME);

        public static IServiceProvider ConfigureServices()
        {
            //setup our DI
            var serviceProvider = new ServiceCollection()
                .AddLogging()
                .AddDbContext<DataContext>(options => options.UseSqlite(SqliteConnection))
                .AddScoped(typeof(IRepository<>), typeof(RepositoryImpl<>))
                //.AddScoped(typeof(IRepository<,>), typeof(RepositoryImpl<,>))     <-- no need register
                .BuildServiceProvider();

            // database
            var context = serviceProvider.GetService<DataContext>();
            SqliteUtils.CreateDatabaseIfNotExists(context, DATABASE_NAME);

            return serviceProvider;
        }
    }
}
