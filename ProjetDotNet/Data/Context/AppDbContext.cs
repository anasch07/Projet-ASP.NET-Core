using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using ProjetDotNet.Models;




namespace ProjetDotNet.Data.Context
{
    public class AppDbContext : DbContext
    {

        private static AppDbContext? _instance;
        public DbSet<User>? User { get; set; }
        public static DbSet<Post>? Post { get; set; }
        public DbSet<Reply>? Reply { get; set; }

        public static AppDbContext Instance
        {
            get
            {
                _instance ??= Instantiate_University_Context();
                return _instance;
            }
        }

        private AppDbContext(DbContextOptions o) : base(o)
        {
            Console.WriteLine("New AppDbContext instance");
        }

        public static AppDbContext Instantiate_University_Context()
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            optionsBuilder.UseSqlite(@"Data Source=ProjetDotNet.db");
            var instance = new AppDbContext(optionsBuilder.Options);

            try
            {
                RelationalDatabaseCreator dbCreator = (RelationalDatabaseCreator)instance.GetService<IDatabaseCreator>();
                dbCreator.CreateTables();
            }
            catch (Exception e)
            {

            }
            return instance;
        }
    }
}