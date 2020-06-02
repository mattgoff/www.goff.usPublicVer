using System.Collections.Generic;
using www.goff.us.Models;

namespace www.goff.us.Data
{
  public interface IPiRepo
  {
      IEnumerable<PiData> GetPiDatas();

      PiData GetLatestPiData();

      void SetPiData(PiData piData);

      bool SaveChanges();
  }
}
