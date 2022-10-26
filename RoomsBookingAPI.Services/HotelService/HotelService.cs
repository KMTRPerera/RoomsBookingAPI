using RoomsBookingAPI.DataAccess;
using RoomsBookingAPI.Models;
using RoomsBookingAPI.Services.View_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomsBookingAPI.Services.HotelService
{
    public class HotelService : IHotelService
    {
        private readonly ApplicationDbContext _context = new ApplicationDbContext();

        public List<HotelDetails> AllHotels()
        {
            return _context.hotelDetails.ToList();
        }

        public HotelDetails GetHotel(int id)
        {
            return _context.hotelDetails.FirstOrDefault(t => t.Id == id);
        }

        public HotelDetails AddHotel(VMHotelDetails Hotel_data)
        {
            var Hotel = new HotelDetails
            {
                Name = Hotel_data.Name,
                address = Hotel_data.address,
                Description = Hotel_data.Description,
                ContactNumber = Hotel_data.ContactNumber
            };

            _context.hotelDetails.Add(Hotel);
            _context.SaveChanges();

            return _context.hotelDetails.Find(Hotel.Id);
        }

        public RoomDetails AddRoom(VMRoomDetails RoomDetails)
        {
            var Room = new RoomDetails
            {
                HotelID = RoomDetails.HotelID,
                PeopleCount = RoomDetails.PeopleCount,
                Price = RoomDetails.Price,
                RoomType = RoomDetails.RoomType
            };
            _context.roomDetails.Add(Room);
            _context.SaveChanges();

            return _context.roomDetails.Find(Room.Id);
        }
    }
}

