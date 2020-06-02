using System.Collections.Generic;
using www.goff.us.Models;

namespace www.goff.us.Data
{
  public interface IHumphreyRepo
  {
    IEnumerable<Humphrey> GetAllHumphreyLaps();

    void AddNewLapData(Humphrey humphrey);

    bool SaveChanges();
  }
}