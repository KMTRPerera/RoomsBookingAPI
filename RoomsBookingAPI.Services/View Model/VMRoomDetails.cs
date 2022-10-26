using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomsBookingAPI.Services.View_Model
{
    public class VMRoomDetails
    {
        public string RoomType { get; set; }
        public string PeopleCount { get; set; }
        public decimal Price { get; set; }
        public int HotelID { get; set; }

    }
}
