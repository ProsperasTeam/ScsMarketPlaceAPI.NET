using Microsoft.EntityFrameworkCore;
using Lenders.DataAccess.Entities;

namespace Lenders.DataAccess
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) 
        { }

        public DbSet<Lender> Lenders { get; set; }
    }
}
