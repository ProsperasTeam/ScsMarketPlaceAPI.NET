using System;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using AuthenticationService.Models;
using AuthenticationService.Models.Account;
using AuthenticationService.Models.Config;
using AuthenticationService.Models.Country;
using AuthenticationService.Models.Organization;

namespace AuthenticationService.Persistence
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

