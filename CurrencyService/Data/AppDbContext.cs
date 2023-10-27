using System;
using CurrencyService.Models;
using Microsoft.EntityFrameworkCore;
namespace CurrencyService.Data
{
	public class AppDbContext : DbContext 
	{
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<CurrencyModel> currency { get; set; }

    }
}

