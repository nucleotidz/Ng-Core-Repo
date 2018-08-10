using CORE.NG.DATA.DBModel;
using Microsoft.EntityFrameworkCore;

namespace CORE.NG.DATA.Context
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