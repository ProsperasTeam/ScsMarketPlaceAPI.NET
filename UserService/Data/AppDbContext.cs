using System;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using UserService.Models;
using UserService.Models.Account;
using UserService.Models.Config;
using UserService.Models.Country;
using UserService.Models.Organization;

namespace UserService.Persistence
{
	public class AppDbContext : DbContext
	{

		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
		{
		}

        public DbSet<AccountModel> account { get; set; }
		public DbSet<ConfigOrgModel> Configs { get; set; }
		public DbSet<CountryModel> Countries { get; set; }
		public DbSet<OrganizationModel> Organizations { get; set; }
		public DbSet<ProductCategoryModel> Products { get; set; }
    }


}

