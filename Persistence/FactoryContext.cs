using System.Linq;
using Alere.Models;
using Microsoft.EntityFrameworkCore;

namespace Alere.Persistence
{
    public class FactoryContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Food> Foods { get; set; }
        public DbSet<Requisition> Requisitions { get; set; }

        public FactoryContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Requisition>()
                .HasOne(e => e.Donor)
                .WithMany(e => e.OrdersReceived)
            ;

            modelBuilder
                .Entity<Requisition>()
                .HasOne(e => e.Receiver)
                .WithMany(e => e.OrdersPlaced)
            ;

            base.OnModelCreating(modelBuilder);
        }
    }
}