using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomsBookingAPI.Services.View_Model
{
    public class VMHotelDetails
    {
        public string Name { get; set; }
        public string ContactNumber { get; set; }
        public string address { get; set; }
        public string Description { get; set; }

        
    }
}
