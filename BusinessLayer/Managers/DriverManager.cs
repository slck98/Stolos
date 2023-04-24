using BusinessLayer.DTO;
using BusinessLayer.Interfaces;
using BusinessLayer.Mappers;
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

    #region GET
    public List<DriverInfo> GetDriverInfos()
	{
		return _repo.GetAllDriverInfos();
	}

	public DriverInfo GetDriverInfoById(int id)
	{
		return _repo.GetDriverInfoById(id);
	}
    #endregion

    #region ADD
    public void AddDriver(DriverInfo di)
    {
        Driver d = DriverMapper.MapDtoToEntity(di);
        _repo.AddDriver(d);
    }
    #endregion

    #region UPDATE
    public void UpdateDriver(DriverInfo di)
    {
        Driver d = DriverMapper.MapDtoToEntity(di);
        _repo.UpdateDriver(d);
    }
    #endregion

    #region DELETE (soft)
    public void DeleteDriver(int id)
    {
        _repo.DeleteDriver(id);
    }
    #endregion
}
