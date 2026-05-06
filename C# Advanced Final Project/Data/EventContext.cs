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


        /// <summary>
        /// Checks if the Database already has an entry based on the Guest.guestUserID and the Guest.AttendingEventId before either adding or updating the database with the proper Value
        /// </summary>
        /// <param name="newGuest"></param>
        public void AddOrUpdateDB(Guest newGuest)
        {
           var dbGuest = this.Guests.FirstOrDefault(g=> g.GuestUserID == newGuest.GuestUserID && g.AttendingEventId == newGuest.AttendingEventId);

            if (dbGuest == null)
            {
                this.Guests.Add(newGuest);
            }
            else
            {

                dbGuest.Address = newGuest.Address;
                dbGuest.DriverID = newGuest.DriverID;
            }
            this.SaveChanges();

        }
        public void BuildDrivers()
        {
            var drivers = this.Drivers.ToList();

            foreach (var driver in drivers) { 
                driver.DriverUser = this.User.Find(driver.DriverUserId);
            
            }
            this.SaveChanges();
        }

        public List<Event> FetchMyEvents(User currentUser)
        {
            var allDrivers = this.Drivers.ToList();
            var allGuests = this.Guests.ToList();
            List<Event> myevents = new List<Event>();

            foreach(var driver in allDrivers) {
                if (driver.DriverUserId == currentUser.Id && driver.AttendingEventId != null)
                {
                    myevents.Add(this.Events.Find(driver.AttendingEventId));
                }
            }
            foreach (var guest in allGuests) {
                if (guest.GuestUser.Id == currentUser.Id) {
                    myevents.Add(this.Events.Find(guest.AttendingEventId));
                }
            
            }

            return myevents;
        }


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

            modelBuilder.Entity<Driver>().HasData(
                new Driver
                {
                    DriverID = 1,
                    DriverUserId = "static-user-id-1",
                    MaxCapacity = 4,
                    remainingPassengers = 4,
                    AttendingEventId = 1,
                });

        }
    }
}
