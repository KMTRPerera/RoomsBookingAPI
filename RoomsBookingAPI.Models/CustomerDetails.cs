using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomsBookingAPI.Models
{
    public class CustomerDetails
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName = "varchar(100)")]
        public string FirstName { get; set; }

        [Column(TypeName = "varchar(100)")]
        public string LastName { get; set; }

        [Column(TypeName = "varchar(11)")]
        public string NIC { get; set; }

        [Column(TypeName = "varchar(200)")]
        public string Email { get; set; }

        [Required]
        [Column(TypeName = "varchar(20)")]
        public string ContactNumber { get; set; }

        public DateTime CheckIN { get; set; }

        public DateTime CheckOut { get; set; }

        [Required]
        [Column(TypeName = "text")]
        public string Description { get; set; }
    }
}
