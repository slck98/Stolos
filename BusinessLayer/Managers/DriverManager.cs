using BusinessLayer.DTO;
using BusinessLayer.Interfaces;
using BusinessLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Managers;

public class DriverManager
{
    private IDriverRepository _repo;

	public DriverManager(IDriverRepository repo)
	{
		_repo = repo;
	}

	public List<Driver> GetAllDrivers()
	{
		return _repo.GetAllDrivers();
	}
	public Driver GetDriverById(int id)
	{
		return _repo.GetDriverById(id);
	}

	public List<DriverInfo> GetDriverInfos()
	{
		return _repo.GetAllDriverInfos();
	}

	public DriverInfo GetDriverInfoById(int id)
	{
		return _repo.GetDriverInfoById(id);
	}
}
