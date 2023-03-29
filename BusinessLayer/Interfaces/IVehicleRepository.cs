using BusinessLayer.DTO;
using BusinessLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interfaces;

/*
 * Adrian B on 17/03
 */
public interface IVehicleRepository
{
    List<VehicleInfo> GetAllVehicleInfos();
    Vehicle GetVehicleByVIN(string vin);
    void AddVehicle(Vehicle vehicle);
}
