using System;
using System.Collections.Generic;
using www.goff.us.Models;
using System.Linq;

namespace www.goff.us.Data
{
  public class SqliteAllergyRepo : IAllergyRepo
  {
    private readonly GoffUSContext _context;

    public SqliteAllergyRepo(GoffUSContext context)
    {
      _context = context;
    }

    public IEnumerable<AllergyData> GetAllergyData()
    {
      return _context.AllergyDatas.ToList();

    }

    public AllergyData GetLatestAllergyData()
    {
      return _context.AllergyDatas.OrderByDescending( s => s.Id).FirstOrDefault();
    }

    public bool SaveChanges()
    {
      return (_context.SaveChanges() >= 0);
    }

    public void SetAllergyData(AllergyData allergyData)
    {
      allergyData.AllergyRecordStamp = $"{DateTime.Now}";
      var recordToUpdate = _context.AllergyDatas.Where( s => s.Id == 1).First();

      recordToUpdate.PollenToday = allergyData.PollenToday;
      recordToUpdate.PollenTomorrow = allergyData.PollenTomorrow;
      recordToUpdate.PollenYesterday = allergyData.PollenYesterday;
      recordToUpdate.AllergyRecordStamp = allergyData.AllergyRecordStamp;

      // _context.AllergyDatas.Add(allergyData);
      _context.SaveChanges();
    }
  }
}