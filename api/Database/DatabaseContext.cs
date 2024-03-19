using ApiMoodleClone.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiMoodleClone.Database
{
    public class DatabaseContext(DbContextOptions<DatabaseContext> options) : DbContext(options)
    {
        public DbSet<User> Users { get; set; }
    }
}
