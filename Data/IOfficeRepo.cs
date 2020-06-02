using System.Collections.Generic;
using www.goff.us.Models;

namespace www.goff.us.Data
{
  public interface IOfficeRepo
  {
      IEnumerable<OfficeTemperature> GetAllOfficeTemps();
      OfficeTemperature GetOfficeTempById(int id);
      void AddNewTemperatureData(OfficeTemperature officeTemperature);
      OfficeTemperature GetOfficeLast();
      bool SaveChanges();
  }
}