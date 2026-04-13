using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRental.Dal;

namespace CarRental.Application
{
    public class VehicleDBService
    {
        private readonly VehicleDBContext _dBContext;

        public VehicleDBService(VehicleDBContext dBContext)
        {
            _dBContext = dBContext;
        }

        public List<Vehicle> getAllVehicles()
        {
            return _dBContext.Vehicles.ToList();
        }

        public void addVehicle(Vehicle vehicle)
        {
            
            _dBContext.Vehicles.Add(vehicle);
            _dBContext.SaveChanges();
        }

        public void deleteVehicle(int id)
        {
            var vehicleInDb = _dBContext.Vehicles.SingleOrDefault(car => car.ID == id);
            if (vehicleInDb != null)
            {
                _dBContext.Vehicles.Remove(vehicleInDb);
                _dBContext.SaveChanges();
            }
        }

        public void updateVehicle(Vehicle vehicle)
        {
            var vehicleInDb = _dBContext.Vehicles.SingleOrDefault(veh => veh.ID == vehicle.ID);
            if (vehicleInDb != null)
            {
                _dBContext.Vehicles.Update(vehicleInDb);
                _dBContext.SaveChanges();
            }
        }

    }
}
