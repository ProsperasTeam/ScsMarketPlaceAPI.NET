using System;
using System.Collections.Generic;
using CountryService.Models;
using Microsoft.EntityFrameworkCore;



namespace CountryService.Data
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Country> country { get; set; }

        
    }
}

