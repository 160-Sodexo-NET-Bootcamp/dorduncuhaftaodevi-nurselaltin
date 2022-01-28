using Entity.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAcces.Concrete.Context
{
    public class ProjectContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<SystemInfo> SystemInformations { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;Database=HangfireProjectDB;Integrated Security=True");
        }
    }
}
