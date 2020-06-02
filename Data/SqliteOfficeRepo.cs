using System;
using System.Collections.Generic;
using www.goff.us.Models;
using System.Linq;

namespace www.goff.us.Data
{
  public class SqliteOfficeRepo : IOfficeRepo
  {
    private readonly GoffUSContext _context;
    public SqliteOfficeRepo(GoffUSContext context)
    {
      _context = context;
    }

    public void AddNewTemperatureData(OfficeTemperature OfficeTemperature)
    {
      OfficeTemperature.OfficeProbeRecordStamp = $"{DateTime.Now}";
      _context.OfficeTemperatures.Add(OfficeTemperature);

    }

    public IEnumerable<OfficeTemperature> GetAllOfficeTemps()
    {
      return _context.OfficeTemperatures.OrderByDescending(m => m.Id).Take(100).ToList();
    }

    public OfficeTemperature GetOfficeLast()
    {
      var lastTemp = _context.OfficeTemperatures.OrderByDescending(m => m.Id).FirstOrDefault();
      return lastTemp;
    }

    public OfficeTemperature GetOfficeTempById(int id)
    {
      return _context.OfficeTemperatures.FirstOrDefault(p => p.Id == id);
    }

    public bool SaveChanges()
    {
      return (_context.SaveChanges() >= 0);
    }
  }
}