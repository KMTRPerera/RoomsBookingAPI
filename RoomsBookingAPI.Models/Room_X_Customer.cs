using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomsBookingAPI.Models
{
    public class Room_X_Customer
    {
        [Key]
        public int Id { get; set; }
        public int CustomerID { get; set; }
        [ForeignKey("CustomerID")]
        public virtual CustomerDetails CustomerDetails { get; set; }
        public int RoomID { get; set; }
        [ForeignKey("RoomID")]
        public virtual RoomDetails RoomDetails { get; set; }
    }
}
