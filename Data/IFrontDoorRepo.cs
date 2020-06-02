using System.Collections.Generic;
using www.goff.us.Models;

namespace www.goff.us.Data
{
  public interface IFrontDoorRepo
  {
      IEnumerable<FrontDoorTemperature> GetAllFrontDoorTemps();

      FrontDoorTemperature GetFrontDoorTempById(int id);

      void AddNewTemperatureData(FrontDoorTemperature frontDoorTemperature);

      FrontDoorTemperature GetFrontDoorLast();

      bool SaveChanges();

  }
}