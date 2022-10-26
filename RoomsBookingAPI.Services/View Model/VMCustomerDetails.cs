using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomsBookingAPI.Services.View_Model
{
    public class VMCustomerDetails
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NIC { get; set; }
        public string Email { get; set; }
        public string ContactNumber { get; set; }
        public DateTime CheckIN { get; set; }
        public DateTime CheckOut { get; set; }
        public string Description { get; set; }
    }
}
