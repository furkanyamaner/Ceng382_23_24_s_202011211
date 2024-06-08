using Microsoft.EntityFrameworkCore;
using MyApp.Models;

namespace Lab11.Data
{
    public class RoomDbContext : DbContext
    {
        public RoomDbContext(DbContextOptions<RoomDbContext> options) : base(options)
        {
        }

        public DbSet<Room> Rooms { get; set; }
    }
}
