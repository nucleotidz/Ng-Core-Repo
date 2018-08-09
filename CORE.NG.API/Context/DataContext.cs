using CORE.NG.API.DBModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CORE.NG.API.Context
{
    public class DataContext : DbContext
    {
     //   public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<user> user { get; set; }
        public DbSet<Team> Team { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connstr = @"Server=IN2290149W1\AHMAR;Database=TestCore;Trusted_Connection=True;";
            optionsBuilder.UseSqlServer(connstr);
        }
    }
}