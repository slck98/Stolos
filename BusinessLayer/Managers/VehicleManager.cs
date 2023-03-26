using BusinessLayer.Interfaces;
using BusinessLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Managers
{
    public class VehicleManager
    {
        private IVehicleRepository _repo;
        public VehicleManager(IVehicleRepository repo)
        {
            _repo = repo;
        }

        public List<Vehicle> GetAllVehicles()
        {
            return _repo.GetAllVehicles();
        }

        public Vehicle GetVehicleByVIN(string vin)
        {
            return _repo.GetVehicleByVIN(vin);
        }

        public void AddVehicle(Vehicle vehicle)
        {
            _repo.AddVehicle(vehicle);
            //if(vehicle.Driver != null)
            //{
            //    if (vehicle.Driver.Vehicle == null)
            //    {
            //        vehicle.Driver.Vehicle = vehicle;
            //    }
            //}
        }
    }
}
