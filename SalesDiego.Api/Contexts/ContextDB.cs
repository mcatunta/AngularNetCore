using Microsoft.EntityFrameworkCore;
using SalesDiego.Api.Configurations;
using SalesDiego.Api.Entities;

namespace SalesDiego.Api.Context
{
    public class ContextDB : DbContext
    {
        public ContextDB(DbContextOptions<ContextDB> options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CategoryProductConfiguration());
            modelBuilder.ApplyConfiguration(new ClientConfiguration());
            modelBuilder.ApplyConfiguration(new DetailOrderConfiguration());
            modelBuilder.ApplyConfiguration(new ImageProductConfiguration());
            modelBuilder.ApplyConfiguration(new OrderConfiguration());
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new StateOrderConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
        }
    }
}
