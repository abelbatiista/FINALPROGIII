using APP.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APP.Data
{
    public class VehicleService : IVehicleService
    {
        private readonly ContextDB _context;
        public VehicleService(ContextDB context)
        {
            _context = context;
        }
        public async Task<bool> DeleteVehicle(int id)
        {
            var vehicle = await _context.Vehicles.FindAsync(id);
            _context.Vehicles.Remove(vehicle);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<IEnumerable<Vehicle>> GetAllVehicle()
        {
            return await _context.Vehicles.ToListAsync();
        }

        public async Task<IEnumerable<Vehicle>> GetBenefitsForVehicle()
        {
            return await _context.Vehicles
                .FromSqlRaw("SELECT V.Brand, V.Kind, V.Color, V.Enrollment, V.Image, V.Latitude, V.Length, V.Model, V.ChargeCapacity, V.SecureNumber, V.VehicleId, V.Year" +
                ", (SELECT COUNT(B.BookingId) FROM dbo.Bookings B WHERE B.VehicleId = V.VehicleId) AS 'PassengersNumber'" +
                ", (SELECT (COUNT(I.InvoiceId)*(V.Price)) FROM dbo.Invoices I INNER JOIN Bookings B ON B.BookingId = I.BookingId WHERE B.VehicleId = V.VehicleId) as 'Price'" +
                " FROM dbo.Vehicles V")
                .ToListAsync();
        }

        public async Task<IEnumerable<Vehicle>> GetClientDebt()
        {
            return await _context.Vehicles
                .FromSqlRaw("SELECT C.Cedula AS 'Brand', C.Name AS 'Model', C.LastName AS 'Color', V.Enrollment, V.Image, V.Latitude, V.Length, V.ChargeCapacity, V.SecureNumber, V.VehicleId, V.Year, V.PassengersNumber, V.Kind, (SELECT(SUM(I.Amount) - (SUM(I.AmountPaid))) FROM Invoices I WHERE I.BookingId = B.BookingId) AS 'Price' FROM Vehicles V  INNER JOIN Bookings B ON V.VehicleId = B.VehicleId INNER JOIN Clients C ON c.ClientId = b.ClientId INNER JOIN Invoices I ON I.BookingId = B.BookingId WHERE I.Amount != I.AmountPaid ")
                .ToListAsync();
        }

        public async Task<Vehicle> GetVehicleDetails(int id)
        {
            return await _context.Vehicles.FindAsync(id);
        }

        public async Task<IEnumerable<Vehicle>> GetVehiclesForDate(string startDate, string endDate)
        {
            return await _context.Vehicles
                .FromSqlRaw($"SELECT V.* FROM Vehicles V INNER JOIN Bookings B ON V.VehicleId = B.VehicleId WHERE ('{startDate}' NOT BETWEEN B.StartDate AND B.EndDate) AND ('{endDate}' NOT BETWEEN B.StartDate AND B.EndDate)")
                .ToListAsync();
        }

        public async Task<bool> InsertVehicle(Vehicle vehicle)
        {
            _context.Vehicles.Add(vehicle);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> SaveVehicle(Vehicle vehicle)
        {
            if (vehicle.VehicleId > 0)
                return await UpdateVehicle(vehicle);
            else
                return await InsertVehicle(vehicle);
        }

        public async Task<bool> UpdateVehicle(Vehicle vehicle)
        {
            _context.Entry(vehicle).State = EntityState.Modified;
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
