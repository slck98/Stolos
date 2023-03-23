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

	public Driver GetDriver(int id)
	{
		return _repo.GetDriver(id);
	}
}
