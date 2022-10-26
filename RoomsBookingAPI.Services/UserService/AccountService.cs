using RoomsBookingAPI.DataAccess;
using RoomsBookingAPI.Models;
using RoomsBookingAPI.Services.View_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomsBookingAPI.Services.UserService
{
    public class AccountService : IAccountService
    {
        private readonly ApplicationDbContext _context = new ApplicationDbContext();

        public List<UserDetails> AllUsers()
        {
            return _context.UserDetails.ToList();
        }

        public UserDetails GetUsers(int id)
        {
            return _context.UserDetails.FirstOrDefault(t => t.Id == id);
        }

        public UserDetails UserRegistration(VMUserDetails UserData)
        {
            var Username = _context.UserDetails.FirstOrDefault(t => t.Username == UserData.EmailAddress);
            var EmailAddress = _context.UserDetails.FirstOrDefault(t => t.EmailAddress == UserData.EmailAddress);
            var result = new UserDetails();
            if (Username == null && EmailAddress == null)
            {
                var User_Data = new UserDetails
                {
                    FirstName = UserData.FirstName,
                    LastName = UserData.LastName,
                    EmailAddress = UserData.EmailAddress,
                    Username = UserData.EmailAddress,
                    DateOfJoing = DateTime.Now,
                    Password = UserData.Password,
                    UserType = UserData.UserType
                };
                _context.UserDetails.Add(User_Data);
                _context.SaveChanges();
                result = _context.UserDetails.Find(User_Data.Id);
            }


            return result;
        }

        public UserDetails AuthenticateUser(VMUserLogin LoginData)
        {
            var User = _context.UserDetails.FirstOrDefault(t => t.Username == LoginData.Username && t.Password == LoginData.Password);

            return User;
        }

    }
}
