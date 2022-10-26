using RoomsBookingAPI.DataAccess;
using RoomsBookingAPI.Models;
using RoomsBookingAPI.Services.View_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomsBookingAPI.Services.CustomerService
{
    public class CustomerService : ICustomerService
    {
        private readonly ApplicationDbContext _context = new ApplicationDbContext();

        public List<CustomerDetails> AllHotels()
        {
            return _context.customerDetails.ToList();
        }

        public CustomerDetails GetCustomer(int id)
        {
            return _context.customerDetails.FirstOrDefault(t => t.Id == id);
        }

        public CustomerDetails AddCustomer(VMCustomerDetails Customer)
        {
            var Customer_Data = new CustomerDetails
            {
                FirstName = Customer.FirstName,
                LastName = Customer.LastName,
                NIC = Customer.NIC,
                Email = Customer.Email,
                CheckIN = Customer.CheckIN,
                CheckOut = Customer.CheckOut,
                ContactNumber = Customer.ContactNumber,
                Description = Customer.Description
            };

            _context.customerDetails.Add(Customer_Data);
            _context.SaveChanges();

            return _context.customerDetails.Find(Customer_Data.Id);
        }

        public CustomerDetails RoomBooking(VMRoom_X_Customer RoomBooking)
        {
            var Booking = new Room_X_Customer
            {
                CustomerID = RoomBooking.CustomerID,
                RoomID = RoomBooking.RoomID
            };

            _context.room_X_Customers.Add(Booking);
            _context.SaveChanges();

            return _context.customerDetails.Find(Booking.Id);
        }

    }
}
