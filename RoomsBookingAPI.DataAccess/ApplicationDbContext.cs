using Microsoft.EntityFrameworkCore;
using RoomsBookingAPI.Models;

namespace RoomsBookingAPI.DataAccess
{
    public class ApplicationDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = "Server=DESKTOP-HAIUS3N\\SQLEXPRESS;Database=RoomsBooking;Trusted_Connection=True;MultipleActiveResultSets=true";
            optionsBuilder.UseSqlServer(connectionString);
        }

        public DbSet<CustomerDetails> customerDetails  { get; set; }
        public DbSet<HotelDetails> hotelDetails { get; set; }
        public DbSet<RoomDetails> roomDetails { get; set; }
        public DbSet<Room_X_Customer> room_X_Customers { get; set; }
        public DbSet<UserDetails> UserDetails { get; set; }
    }
}
