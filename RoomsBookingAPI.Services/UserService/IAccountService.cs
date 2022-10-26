using RoomsBookingAPI.Models;
using RoomsBookingAPI.Services.View_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomsBookingAPI.Services.UserService
{
    public interface IAccountService
    {
        List<UserDetails> AllUsers();
        UserDetails GetUsers(int id);
        UserDetails UserRegistration(VMUserDetails UserData);
        UserDetails AuthenticateUser(VMUserLogin LoginData);
        
    }
}
