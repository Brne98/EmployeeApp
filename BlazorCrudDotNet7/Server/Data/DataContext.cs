using BlazorCrudDotNet7.Shared.Entities;
using Microsoft.EntityFrameworkCore;

namespace BlazorCrudDotNet7.Server.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>();
            modelBuilder.Entity<Employee>();
            modelBuilder.Entity<Category>();
        }

        public DbSet<Product> Products => Set<Product>();
        public DbSet<Employee> Employees => Set<Employee>();
        public DbSet<User> Users => Set<User>();
        public DbSet<Category> Categories => Set<Category>();
    }
}