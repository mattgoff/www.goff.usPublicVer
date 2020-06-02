using System;
using System.Collections.Generic;
using www.goff.us.Models;
using System.Linq;

namespace www.goff.us.Data
{
  public class SqliteFrontDoorRepo : IFrontDoorRepo
  {
    private readonly GoffUSContext _context;
    public SqliteFrontDoorRepo(GoffUSContext context)
    {
      _context = context;
    }

    public void AddNewTemperatureData(FrontDoorTemperature FrontDoorTemperature)
    {
      FrontDoorTemperature.FrontProbeRecordStamp = $"{DateTime.Now}";
      _context.FrontDoorTemperatures.Add(FrontDoorTemperature);

    }

    public IEnumerable<FrontDoorTemperature> GetAllFrontDoorTemps()
    {
      return _context.FrontDoorTemperatures.OrderByDescending(m => m.Id).Take(100).ToList();
    }

    public FrontDoorTemperature GetFrontDoorLast()
    {
      var lastTemp = _context.FrontDoorTemperatures.OrderByDescending(m => m.Id).FirstOrDefault();
      return lastTemp;
    }

    public FrontDoorTemperature GetFrontDoorTempById(int id)
    {
      return _context.FrontDoorTemperatures.FirstOrDefault(p => p.Id == id);
    }

    public bool SaveChanges()
    {
      return (_context.SaveChanges() >= 0);
    }
  }
}