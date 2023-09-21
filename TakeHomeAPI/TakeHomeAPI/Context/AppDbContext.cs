using Microsoft.EntityFrameworkCore;
using TakeHomeAPI.Models;

namespace TakeHomeAPI.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("users");
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    FirstName = "Janith",
                    LastName = "Udayanga",
                    Email = "janith0000@gmail.com",
                    UserName = "janith",
                    Password = "123",
                    Role = "user",
                    Token = "1"
                }, 
                new User
                {
                    Id = 2,
                    FirstName = "Admin",
                    LastName = "Something",
                    Email = "admin@gmail.com",
                    UserName = "admin",
                    Password = "123",
                    Role = "admin",
                    Token = "1"
                }
                );
        }

    }
}
