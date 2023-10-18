using System;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using AuthenticationService.Models;
namespace AuthenticationService.Persistence
{
	public class AppDbContext : DbContext
	{

		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
		{
		}

        public DbSet<Organization> org { get; set; }
		public DbSet<User> user { get; set; }

    }


}

