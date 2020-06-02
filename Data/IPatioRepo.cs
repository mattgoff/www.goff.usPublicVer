using System.Collections.Generic;
using www.goff.us.Models;

namespace www.goff.us.Data
{
  public interface IPatioRepo
  {
      IEnumerable<PatioTemperature> GetAllPatioTemps();
      PatioTemperature GetPatioTempById(int id);
      void AddNewTemperatureData(PatioTemperature patioTemperature);
      PatioTemperature GetPatioLast();
      bool SaveChanges();

  }
}