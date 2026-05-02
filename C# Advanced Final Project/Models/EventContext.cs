using Microsoft.EntityFrameworkCore;

namespace C__Advanced_Final_Project.Models
{
    public class EventContext : DbContext
    {
        public EventContext(DbContextOptions<EventContext> options) : base(options) { }

        public DbSet<Event> Events { get; set; } = null!;
        public DbSet<Guest> Guests { get; set; } = null!;

        public DbSet<Driver> Drivers { get; set; } = null!;

    }
}
