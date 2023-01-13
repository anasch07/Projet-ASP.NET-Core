using Microsoft.EntityFrameworkCore;
using ProjetDotNet.Models;

namespace ProjetDotNet.Data;



public class AppDbContext : DbContext
{

    private static AppDbContext? _instance;
    public DbSet<User>? User { get; set; }
    public DbSet<Post>? Post { get; set; }
    public DbSet<Reply>? Reply { get; set; }
    
    public static AppDbContext Instance
    {
        get
        {
            _instance ??= Instantiate_University_Context();
            return _instance;
        }
    }

    private AppDbContext(DbContextOptions o) : base(o) {
        Console.WriteLine("New AppDbContext instance");
    }

    public static AppDbContext Instantiate_University_Context()
    {
        var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
        optionsBuilder.UseSqlite(@"Data Source=ProjetDotNet.db");

        return new AppDbContext(optionsBuilder.Options);
    }
}