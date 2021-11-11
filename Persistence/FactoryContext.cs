using Alere.Models;
using Microsoft.EntityFrameworkCore;

namespace Alere.Persistence
{
    public class FactoryContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public FactoryContext(DbContextOptions options) : base(options) { }

    }
}