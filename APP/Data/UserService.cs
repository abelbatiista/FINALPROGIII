using APP.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APP.Data
{
    public class UserService : IUserService
    {
        private readonly ContextDB _context;
        public UserService(ContextDB context)
        {
            _context = context;
        }
        public async Task<bool> DeleteUser(int id)
        {
            var user = await _context.Users.FindAsync(id);
            _context.Users.Remove(user);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<IEnumerable<User>> GetAllUser()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User> GetUserDetails(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task<bool> InsertUser(User user)
        {
            _context.Users.Add(user);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<User> LogIn(string email)
        {
            return await _context.Users
                .FromSqlRaw($"SELECT * FROM Users U WHERE U.Email = '{email}'")
                .SingleAsync();
        }

        public async Task<bool> SaveUser(User user)
        {
            if (user.UserId > 0)
                return await UpdateUser(user);
            else
                return await InsertUser(user);
        }

        public async Task<bool> UpdateUser(User user)
        {
            _context.Entry(user).State = EntityState.Modified;
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
