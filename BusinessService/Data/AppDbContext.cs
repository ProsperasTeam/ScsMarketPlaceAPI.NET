using System;
using BusinessService.Models.Business;
using Microsoft.EntityFrameworkCore;

namespace BusinessService.Data
{
	public class AppDbContext:DbContext
	{
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<BusinessModel> Business { get; set; }
    }
}

