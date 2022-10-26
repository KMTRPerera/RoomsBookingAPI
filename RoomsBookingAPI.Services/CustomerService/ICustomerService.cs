using RoomsBookingAPI.Models;
using RoomsBookingAPI.Services.View_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomsBookingAPI.Services.CustomerService
{
    public interface ICustomerService
    {
        List<CustomerDetails> AllHotels();
        CustomerDetails GetCustomer(int id);
        CustomerDetails AddCustomer(VMCustomerDetails Customer);
        CustomerDetails RoomBooking(VMRoom_X_Customer RoomBooking);

    }
}
