using System;
using System.ComponentModel.DataAnnotations;

namespace www.goff.us.Models
{
  public class PatioTemperature
  {
    public int Id { get; set; }
    public double PatioProbeTemp { get; set; }
    public string PatioProbeRecordStamp {get; set;}
  }
}
