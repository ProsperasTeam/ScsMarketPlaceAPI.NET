using Microsoft.EntityFrameworkCore;
using be = Business.DataAccess.Entities;

namespace Business.DataAccess
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) 
        { }

        public DbSet<be.Business> Business { get; set; }
    }
}
