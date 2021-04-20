using APP.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APP.Data
{
    public class ClientService : IClientService
    {
        private readonly ContextDB _context;
        public ClientService(ContextDB context)
        {
            _context = context;
        }

        public async Task<bool> DeleteClient(int id)
        {
            var client = await _context.Clients.FindAsync(id);
            _context.Clients.Remove(client);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<IEnumerable<Client>> GetAllClient()
        {
            return await _context.Clients.ToListAsync();
        }

        public async Task<Client> GetClientDetails(int id)
        {
            return await _context.Clients.FindAsync(id);
        }

        public async Task<bool> InsertClient(Client client)
        {
            _context.Clients.Add(client);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> SaveClient(Client client)
        {
            if (client.ClientId > 0)
                return await UpdateClient(client);
            else
                return await InsertClient(client);
        }

        public async Task<bool> UpdateClient(Client client)
        {
            _context.Entry(client).State = EntityState.Modified;
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
