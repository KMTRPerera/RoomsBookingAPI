using RoomsBookingAPI.Models;
using RoomsBookingAPI.Services.View_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomsBookingAPI.Services.AuthenticationService
{
    public interface IjwtAuthenticationManager
    {
        string GenerateJSONWebToken(UserDetails userInfo);
    }
}
