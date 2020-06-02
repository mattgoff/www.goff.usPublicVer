using System;
using www.goff.us.Data;
using www.goff.us.Models;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace www.goff.us.Controllers
{
  [Route("api/weather")]
  [ApiController]

  public class WeatherController : ControllerBase
  {
    private readonly IWeatherRepo _repository;

    public WeatherController(IWeatherRepo repository)
    {
      _repository = repository;
    }

    [HttpGet]
    public ActionResult <WeatherData> GetWeatherData(){
      var weatherData = _repository.GetWeatherData();
      return Ok(weatherData);
    }

    [Authorize(Roles = "iot")]
    [HttpPost]
    public ActionResult <WeatherData> SetWeatherData(WeatherData weatherData)
    {
      Console.WriteLine("Incoming WeatherData");
      _repository.SetWeatherData(weatherData);
      _repository.SaveChanges();
      return Ok();
    }
  }


}