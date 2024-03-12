using API___moddle_clone.Model;
using Microsoft.EntityFrameworkCore;

namespace API___moddle_clone.Database
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }
      //  public DbSet<Test> tests { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
