using System;
using ConsumerService.Models;
using Microsoft.EntityFrameworkCore;

namespace ConsumerService.Data
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
            public DbSet<ConsumerModel> Consumers { get; set; }
        
    }
}

