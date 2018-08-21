using CORE.NG.DATA.DBModel;
using Microsoft.EntityFrameworkCore;

namespace CORE.NG.DATA.Context
{
    public class DataContext : Repository, IDataContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<User> User { get; set; }
        public DbSet<Team> Team { get; set; }

        public DbSet<Role> Role { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    string connstr = @"Server=IN2290149W1\AHMAR;Database=TestCore;Trusted_Connection=True;";
        //    optionsBuilder.UseSqlServer(connstr);
        //}
    }
}