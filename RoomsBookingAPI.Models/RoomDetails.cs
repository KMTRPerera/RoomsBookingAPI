using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomsBookingAPI.Models
{
    public class RoomDetails
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName = "varchar(200)")]
        public string RoomType { get; set; }

        [Required]
        [Column(TypeName = "varchar(20)")]
        public string PeopleCount { get; set; }

        [Column(TypeName = "decimal(5, 2)")]
        public decimal Price { get; set; }

        public int HotelID { get; set; }
        [ForeignKey("HotelID")]
        public virtual HotelDetails HotelDetails { get; set; }

    }
}
