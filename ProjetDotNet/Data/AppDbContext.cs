using Microsoft.EntityFrameworkCore;
using ProjetDotNet.Models;

namespace ProjetDotNet.Data;

public class AppDbContext : DbContext
{
    
    public DbSet <User> Users { get; set; }
    static private AppDbContext appDbContextInstance = null;
    static public int count = 0;
    
    
    public AppDbContext(DbContextOptions o) : base(o)
    {
    count++;    
    }

    static public AppDbContext Instantiate_AppDbContext()
    {
        if (appDbContextInstance == null)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            optionsBuilder.UseSqlite("Data Source=ProjetDotNet.db");
            return new AppDbContext(optionsBuilder.Options);
        }
        else
        {
            return appDbContextInstance;
        }
    }
}
