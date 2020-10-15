using IOTA.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace IOTA.Models
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        {
        }

        public DbSet<Login> Login { get; set; }
    }
}