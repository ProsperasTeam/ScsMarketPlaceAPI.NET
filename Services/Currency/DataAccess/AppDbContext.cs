using Microsoft.EntityFrameworkCore;
using cu = Currency.DataAccess.Entities;

namespace Currency.DataAccess
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) 
        { }

        public DbSet<cu.Currency> Currency { get; set; }
    }
}
