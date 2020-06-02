using System;
using System.Collections.Generic;
using www.goff.us.Models;
using System.Linq;

namespace www.goff.us.Data
{
  public class SqliteWeatherRepo : IWeatherRepo
  {
    private readonly GoffUSContext _context;

    public SqliteWeatherRepo(GoffUSContext context)
    {
      _context = context;
    }
    public WeatherData GetWeatherData()
    {
      return _context.WeatherDatas.OrderByDescending ( s => s.Id).FirstOrDefault();
    }

    public bool SaveChanges()
    {
      return ( _context.SaveChanges() >= 0);
    }

    public void SetWeatherData(WeatherData weatherData)
    {
      weatherData.WeatherRecordStamp = $"{DateTime.Now}";

      var recordToUpdate = _context.WeatherDatas.Where (s => s.Id == 1).First();

      recordToUpdate.WeatherDataCurrent = weatherData.WeatherDataCurrent;
      recordToUpdate.WeatherDataDay0 = weatherData.WeatherDataDay0;
      recordToUpdate.WeatherDataDay1 = weatherData.WeatherDataDay1;
      recordToUpdate.WeatherDataDay2 = weatherData.WeatherDataDay2;
      recordToUpdate.WeatherDataDay3 = weatherData.WeatherDataDay3;
      recordToUpdate.WeatherRecordStamp= weatherData.WeatherRecordStamp;

      _context.SaveChanges();
    }
  }
}