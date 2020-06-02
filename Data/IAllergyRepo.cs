using System.Collections.Generic;
using www.goff.us.Models;

namespace www.goff.us.Data
{
  public interface IAllergyRepo
  {
    IEnumerable<AllergyData> GetAllergyData();

    AllergyData GetLatestAllergyData();

    void SetAllergyData(AllergyData allergyData);

    bool SaveChanges();

  }
}