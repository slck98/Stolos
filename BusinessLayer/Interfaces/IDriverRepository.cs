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
public interface IDriverRepository
{
    List<Driver> GetAllDrivers();
    Driver GetDriverById(int id);

    List<DriverInfo> GetAllDriverInfos();
    DriverInfo GetDriverInfoById(int id);
}
