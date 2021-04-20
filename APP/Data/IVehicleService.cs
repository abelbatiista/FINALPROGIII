using APP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APP.Data
{
    public interface IVehicleService
    {
        Task<IEnumerable<Vehicle>> GetAllVehicle();
        Task<Vehicle> GetVehicleDetails(int id);
        Task<bool> InsertVehicle(Vehicle vehicle);
        Task<bool> UpdateVehicle(Vehicle vehicle);
        Task<bool> DeleteVehicle(int id);
        Task<bool> SaveVehicle(Vehicle vehicle);
        Task<IEnumerable<Vehicle>> GetBenefitsForVehicle();
        Task<IEnumerable<Vehicle>> GetClientDebt();
    }
}
