using APP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APP.Data
{
    public interface IBookingService
    {
        Task<IEnumerable<Booking>> GetAllBooking();
        Task<Booking> GetBookingDetails(int id);
        Task<bool> InsertBooking(Booking booking);
        Task<bool> UpdateBooking(Booking booking);
        Task<bool> DeleteBooking(int id);
        Task<bool> SaveBooking(Booking booking);
    }
}
