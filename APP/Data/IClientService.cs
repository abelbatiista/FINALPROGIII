using APP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APP.Data
{
    public interface IClientService
    {
        Task<IEnumerable<Client>> GetAllClient();
        Task<Client> GetClientDetails(int id);
        Task<bool> InsertClient(Client client);
        Task<bool> UpdateClient(Client client);
        Task<bool> DeleteClient(int id);
        Task<bool> SaveClient(Client client);
    }
}
