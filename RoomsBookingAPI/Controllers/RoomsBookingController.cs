using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RoomsBookingAPI.Services.CustomerService;
using RoomsBookingAPI.Services.View_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RoomsBookingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class RoomsBookingController : Controller
    {
        private readonly ICustomerService _service;
        public RoomsBookingController(ICustomerService service)
        {
            _service = service;
        }

        [HttpPost("AddCustomer")]
        public IActionResult AddCustomer(VMCustomerDetails CustomerDetails)
        {
            IActionResult response = Unauthorized();
            var Room = _service.AddCustomer(CustomerDetails);

            if (Room != null)
            {
                response = Ok(new { Room = Room });
            }
            else
                response = NotFound(new { Error = "Error : please check the entered data again" });

            return response;
        }

        [HttpPost("RoomBooking")]
        public IActionResult RoomBooking(VMRoom_X_Customer RoomBooking)
        {
            IActionResult response = Unauthorized();
            var Booking = _service.RoomBooking(RoomBooking);

            if (Booking != null)
            {
                response = Ok(new { Booking = Booking });
            }
            else
                response = NotFound(new { Error = "Error : please check the entered data again" });

            return response;
        }
    }
}
