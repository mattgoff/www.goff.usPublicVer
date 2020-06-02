using System.Collections.Generic;
using www.goff.us.Models;

namespace www.goff.us.Data
{
  public interface IWeatherRepo
  {
    WeatherData GetWeatherData();

    void SetWeatherData(WeatherData weatherData);

    bool SaveChanges();

  }
}