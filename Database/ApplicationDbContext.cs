using Entities;
using Microsoft.EntityFrameworkCore;

namespace Database
{
    internal class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {
            //Database.EnsureDeleted();
            //Database.EnsureCreated();
        }
        public DbSet<HotelEntity> Hotels { get; set; }
        public DbSet<RoomEntity> Rooms { get; set; }
        public DbSet<CustomerEntity> Customers { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=SoftwareCompanyDb");
        }
    }
}
