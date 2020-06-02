using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using www.goff.us.Data;
using www.goff.us.Models;

namespace www.goff.us.Pages
{
  public class WeatherDataModel : PageModel
  {
    private readonly GoffUSContext _db;

    public WeatherDataModel(GoffUSContext db)
    {
      _db = db;
    }

    public WeatherData WeatherDatas { get; set; }
    public string[] weatherDataCurrent { get; set; }
    public string[] weatherDataDay0 { get; set; }
    public string[] weatherDataDay1 { get; set; }
    public string[] weatherDataDay2 { get; set; }
    public string[] weatherDataDay3 { get; set; }
    public string weatherTimeStamp {get; set;}
    public void OnGet()
    {
      WeatherDatas = _db.WeatherDatas.OrderByDescending(s => s.Id).FirstOrDefault();
      weatherDataCurrent = WeatherDatas.WeatherDataCurrent.Split(",");
      weatherDataDay0 = WeatherDatas.WeatherDataDay0.Split(",");
      weatherDataDay1 = WeatherDatas.WeatherDataDay1.Split(",");
      weatherDataDay2 = WeatherDatas.WeatherDataDay2.Split(",");
      weatherDataDay3 = WeatherDatas.WeatherDataDay3.Split(",");
      weatherTimeStamp = WeatherDatas.WeatherRecordStamp;

    }
  }
}
