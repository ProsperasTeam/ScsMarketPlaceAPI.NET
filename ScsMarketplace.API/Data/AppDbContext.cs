using System;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using ScsMarketplace.API.Models;
using ScsMarketplace.API.Models.Account;
using ScsMarketplace.API.Models.Config;
using ScsMarketplace.API.Models.Country;
using ScsMarketplace.API.Models.Organization;

namespace ScsMarketplace.API.Persistence
{
	public class AppDbContext : DbContext
	{

		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
		{
		}

        public DbSet<AccountModel> Accounts { get; set; }
		public DbSet<ConfigOrgModel> Configs { get; set; }
		public DbSet<CountryModel> Countries { get; set; }
		public DbSet<OrganizationModel> Organizations { get; set; }
		public DbSet<ProductCategoryModel> Products { get; set; }
    }


}

