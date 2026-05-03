using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using C__Advanced_Final_Project.Models;

namespace C__Advanced_Final_Project.Data
{
    public class EventContext : IdentityDbContext<User>
    {
        public EventContext(DbContextOptions<EventContext> options) : base(options) { }
       
        public DbSet<Event> Events { get; set; } = null!;
        public DbSet<Guest> Guests { get; set; } = null!;

        public DbSet<Driver> Drivers { get; set; } = null!;
        public DbSet<User> User { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.Entity<Event>().HasData(
            new Event
            {
                EventID = 1,
                Name = "Test",
                Description = "Test",
                Location = "TestLocation",
                EventDate = DateOnly.MinValue,
                Drivers = 0

            }
            );
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = "static-user-id-1",
                    UserName = "owsurg@gmail.com",
                    NormalizedUserName = "OWSURG@GMAIL.COM",
                    Email = "owsurg@gmail.com",
                    NormalizedEmail = "OWSURG@GMAIL.COM",
                    EmailConfirmed = false,
                    PasswordHash = "test",
                    LName = "lname",
                    FName = "fname",
                    SecurityStamp = "static-security-stamp-1",
                    ConcurrencyStamp = "static-concurrency-stamp-1"
                }
            );
        }
    }
}
