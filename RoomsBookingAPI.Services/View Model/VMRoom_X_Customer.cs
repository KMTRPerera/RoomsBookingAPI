using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomsBookingAPI.Services.View_Model
{
    public class VMRoom_X_Customer
    {
        public int Id { get; set; }
        public int CustomerID { get; set; }
        public int RoomID { get; set; }
    }
}
