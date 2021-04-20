using APP.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APP.Data
{
    public class BookingService : IBookingService
    {
        private readonly ContextDB _context;
        public BookingService(ContextDB context)
        {
            _context = context;
        }
        public async Task<bool> DeleteBooking(int id)
        {
            var booking = await _context.Bookings.FindAsync(id);
            _context.Bookings.Remove(booking);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<IEnumerable<Booking>> GetAllBooking()
        {
            return await _context.Bookings.ToListAsync();
        }

        public async Task<Booking> GetBookingDetails(int id)
        {
            return await _context.Bookings.FindAsync(id);
        }

        public async Task<bool> InsertBooking(Booking booking)
        {
            _context.Bookings.Add(booking);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> SaveBooking(Booking booking)
        {
            if (booking.BookingId > 0)
                return await UpdateBooking(booking);
            else
                return await InsertBooking(booking);
        }

        public async Task<bool> UpdateBooking(Booking booking)
        {
            _context.Entry(booking).State = EntityState.Modified;
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
