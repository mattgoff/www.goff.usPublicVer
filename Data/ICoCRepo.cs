using System.Collections.Generic;
using www.goff.us.Models;

namespace www.goff.us.Data
{
  public interface ICoCRepo
  {
      IEnumerable<CoCPlayer> GetCoCPlayers();

      CoCPlayer GetCoCPlayerById(string coCPlayer);

      void SetCoCData(CoCPlayer coCPlayer);

      bool SaveChanges();
  }
}
