using System;

namespace www.goff.us.Models
{
  public class OfficeTemperature
  {
    public int Id { get; set;}
    public double OfficeProbeTemp { get; set; }
    public double OfficeProbeHumidity { get; set; }
    public string OfficeProbeRecordStamp { get; set; }
  }
}