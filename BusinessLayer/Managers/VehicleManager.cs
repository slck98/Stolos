using BusinessLayer.DTO;
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

        public List<VehicleInfo> GetAllVehicleInfos()
        {
            return _repo.GetAllVehicleInfos();
        }

        public VehicleInfo GetVehicleByVIN(string vin)
        {
            return _repo.GetVehicleByVIN(vin);
        }

       
        public void AddVehicle(Vehicle vehicle)
        {
            _repo.AddVehicle(vehicle);
        }

        public void AddVehicle(VehicleInfo vehicleInfo)
        {
            _repo.AddVehicle(vehicleInfo);
        }
    }
}
