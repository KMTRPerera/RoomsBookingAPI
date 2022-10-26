using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomsBookingAPI.Models
{
    public class HotelDetails
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName = "varchar(200)")]
        public string Name { get; set; }

        [Required]
        [Column(TypeName = "varchar(20)")]
        public string ContactNumber { get; set; }

        [Column(TypeName = "text")]
        public string address { get; set; }

        [Required]
        [Column(TypeName = "text")]
        public string Description { get; set; }

        
    }
}
