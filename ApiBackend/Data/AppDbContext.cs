using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiBackend.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiBackend.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
            
        }
        //register the stock model

        public DbSet<Stock> Stocks { get; set; }
        //register the comment model
        public DbSet<Comments> Comments { get; set; }
    }
}