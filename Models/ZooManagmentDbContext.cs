using Microsoft.EntityFrameworkCore;
using zoo_mgmt.Models.Database;

namespace zoo_mgmt
{
    public class ZooManagementDbContext : DbContext
    {
        public ZooManagementDbContext(DbContextOptions<ZooManagementDbContext> options) : base(options) { }

        public DbSet<Animal> Animals { get; set; }
        public DbSet<Enclosure> Enclosures { get; set; }
        public DbSet<ZooKeeper> ZooKeepers { get; set; }
    }
}