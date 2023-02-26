using Authentication.Backend.Domain.Models;
using Authentication.Backend.Infrastructure.Data.Configs.UserConfig;
using Microsoft.EntityFrameworkCore;

namespace Authentication.Backend.Infrastructure.Data.Contexts
{
    public class BackendContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(@"Host=127.0.0.1; Port=5432; Database=root; Username=root; Password=root");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new UserConfig());
        }
    }
}
