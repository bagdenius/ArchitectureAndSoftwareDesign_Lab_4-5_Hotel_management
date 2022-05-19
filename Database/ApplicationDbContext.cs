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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<HotelEntity>()
                .HasMany(h => h.Rooms)
                .WithOne(r => r.Hotel)
                .HasForeignKey(r => r.HotelId);
            modelBuilder.Entity<RoomEntity>()
                .HasOne(r => r.Customer)
                .WithOne(c => c.Room)
                .HasForeignKey<CustomerEntity>(c => c.RoomId);
            modelBuilder.Entity<CustomerEntity>()
                .HasOne(c => c.Room)
                .WithOne(r => r.Customer)
                .IsRequired();
        }
    }
}
