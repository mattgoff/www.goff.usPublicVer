using System;
using System.ComponentModel.DataAnnotations;

namespace www.goff.us.Models
{
  public class AllergyData
  {
    public int Id { get; set; }
    public string PollenYesterday { get; set; }
    public string PollenToday { get; set; }
    public string PollenTomorrow { get; set; }
    public string AllergyRecordStamp { get; set; }
  }
}
