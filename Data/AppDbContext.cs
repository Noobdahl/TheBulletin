using Microsoft.EntityFrameworkCore;
using TheBulletin.Models;

namespace TheBulletin.Data
{
    internal class AppDbContext : DbContext
    {
        public AppDbContext() { }
        public AppDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Message> Messages { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=TheBulletinDb;Trusted_Connection=True;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasData(
                new User()
                {
                    UserId = 1,
                    Name = "Micke",
                    Password = "asd",
                    IsAdmin = true,
                }
                );
            modelBuilder.Entity<Room>()
                .HasData(
                new Room()
                {
                    RoomId = 1,
                    Name = "General"
                }
                );
        }
    }
}
