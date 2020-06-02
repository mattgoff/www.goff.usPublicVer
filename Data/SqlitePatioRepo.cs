using System;
using System.Collections.Generic;
using www.goff.us.Models;
using System.Linq;

namespace www.goff.us.Data
{
  public class SqlitePatioRepo : IPatioRepo
  {
    private readonly GoffUSContext _context;
    public SqlitePatioRepo(GoffUSContext context)
    {
      _context = context;
    }

    public void AddNewTemperatureData(PatioTemperature patioTemperature)
    {
      patioTemperature.PatioProbeRecordStamp = $"{DateTime.Now}";
      _context.PatioTemperatures.Add(patioTemperature);

    }

    public IEnumerable<PatioTemperature> GetAllPatioTemps()
    {
      return _context.PatioTemperatures.OrderByDescending(m => m.Id).Take(100).ToList();
    }

    public PatioTemperature GetPatioLast()
    {
      var lastTemp = _context.PatioTemperatures.OrderByDescending(m => m.Id).FirstOrDefault();
      // PatioTemperature latestPationTemp = new PatioTemperature();
      // latestOfficeTemp.PatioProbeTemp = lastTemp.O
      return lastTemp;
    }

    public PatioTemperature GetPatioTempById(int id)
    {
      return _context.PatioTemperatures.FirstOrDefault(p => p.Id == id);
    }

    public bool SaveChanges()
    {
      return (_context.SaveChanges() >= 0);
    }
  }
}