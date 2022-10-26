using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using RoomsBookingAPI.Services.HotelService;
using RoomsBookingAPI.Services.View_Model;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace RoomsBookingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class HotelsController : Controller
    {
        private readonly IHotelService _hotelService;

        public HotelsController(IHotelService hotelService)
        {
            _hotelService = hotelService;
        }

        [HttpPost("AddHotel")]
        public IActionResult AddHotel(VMHotelDetails HotelDetails)
        {
            IActionResult response = Unauthorized();
            var Hotel = _hotelService.AddHotel(HotelDetails);

            if (Hotel != null)
            {
                response = Ok(new { token = Hotel });
            }
            else
                response = NotFound(new { Error = "Error : please check the entered data again" });

            return response;
        }

        [HttpGet("HotelsList")]
        public IActionResult UsersList()
        {
            IActionResult response = Unauthorized();
            var user = _hotelService.AllHotels();


            response = Ok(new { UsersList = user });

            return response;
        }

        [HttpPost("AddHotelRoom")]
        public IActionResult AddHotelRoom(VMRoomDetails RoomDetails)
        {
            IActionResult response = Unauthorized();
            var Room = _hotelService.AddRoom(RoomDetails);

            if (Room != null)
            {
                response = Ok(new { token = Room });
            }
            else
                response = NotFound(new { Error = "Error : please check the entered data again" });

            return response;
        }

    }
}
