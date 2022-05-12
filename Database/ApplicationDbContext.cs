using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Proxies;

namespace Database
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {
            //Database.EnsureDeleted();
            Database.EnsureCreated();
        }
        public DbSet<HotelEntity> Hotels { get; set; }
        public DbSet<RoomEntity> Rooms { get; set; }
        public DbSet<CustomerEntity> Customers { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=HotelManagementDb");
            optionsBuilder.UseLazyLoadingProxies(false);
        }
    }
}
