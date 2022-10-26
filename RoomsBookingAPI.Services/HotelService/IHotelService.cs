using RoomsBookingAPI.Models;
using RoomsBookingAPI.Services.View_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomsBookingAPI.Services.HotelService
{
    public interface IHotelService
    {
        List<HotelDetails> AllHotels();
        HotelDetails GetHotel(int id);
        HotelDetails AddHotel(VMHotelDetails Hotel);
        RoomDetails AddRoom(VMRoomDetails RoomDetails);
    }
}
