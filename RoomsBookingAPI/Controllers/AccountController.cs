using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RoomsBookingAPI.Services.AuthenticationService;
using RoomsBookingAPI.Services.UserService;
using RoomsBookingAPI.Services.View_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RoomsBookingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : Controller
    {
        private readonly IjwtAuthenticationManager _jwtAuthenticationToken;
        private readonly IAccountService _Authentication;

        public AccountController(IjwtAuthenticationManager jwtAuthentication, IAccountService Authentication)
        {
            _jwtAuthenticationToken = jwtAuthentication;
            _Authentication = Authentication;
        }

        [AllowAnonymous]
        [HttpPost("Login")]
        public IActionResult Login(VMUserLogin loginDetails)
        {
            IActionResult response = Unauthorized();
            var user = _Authentication.AuthenticateUser(loginDetails);

            if (user != null)
            {
                var tokenString = _jwtAuthenticationToken.GenerateJSONWebToken(user);
                response = Ok(new { token = tokenString });
            }
            else
                response = NotFound(new { Error = "Error : your entered username or password is incorrect" });

            return response;
        }

        [AllowAnonymous]
        [HttpPost("Register")]
        public IActionResult Register(VMUserDetails UserDetails)
        {
            IActionResult response = Unauthorized();
            var user = _Authentication.UserRegistration(UserDetails);

            if (user != null)
            {
                var tokenString = _jwtAuthenticationToken.GenerateJSONWebToken(user);
                response = Ok(new { token = tokenString });
            }
            else
                response = NotFound(new { Error = "Error : please check the entered data again" });

            return response;
        }

        [Authorize]
        [HttpGet("UsersList")]
        public IActionResult UsersList()
        {
            IActionResult response = Unauthorized();
            var user = _Authentication.AllUsers();


            response = Ok(new { UsersList = user });

            return response;
        }

        //[Route("test")]
        //[HttpGet]
        //[Authorize]
        //public ActionResult<IEnumerable<string>> Get()
        //{
        //    var currentUser = HttpContext.User;
        //    int spendingTimeWithCompany = 0;

        //    if (currentUser.HasClaim(c => c.Type == "DateOfJoing"))
        //    {
        //        DateTime date = DateTime.Parse(currentUser.Claims.FirstOrDefault(c => c.Type == "DateOfJoing").Value);
        //        spendingTimeWithCompany = DateTime.Today.Year - date.Year;
        //    }

        //    if (spendingTimeWithCompany > 5)
        //    {
        //        return new string[] { "High Time1", "High Time2", "High Time3", "High Time4", "High Time5" };
        //    }
        //    else
        //    {
        //        return new string[] { "value1", "value2", "value3", "value4", "value5" };
        //    }
        //}
        //public IActionResult Index()
        //{
        //    return View();
        //}
    }
}
