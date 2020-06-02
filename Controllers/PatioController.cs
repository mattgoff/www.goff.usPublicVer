using System;
using www.goff.us.Data;
using www.goff.us.Models;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;


namespace www.goff.us.Controllers
{
  [Route("api/patio")]
  [ApiController]

  public class PatioController : ControllerBase
  {
    private readonly IPatioRepo _repository;
    public PatioController(IPatioRepo repository)
    {
      _repository = repository;
    }

  [HttpGet]
  public ActionResult <IEnumerable<PatioTemperature>> GetAllPatioTemps()
  {
    var patioTemperatureItems = _repository.GetAllPatioTemps();
    return Ok(patioTemperatureItems);
  }
  [HttpGet("{id}")]
  public ActionResult <PatioTemperature> GetPatioTempById(int id)
  {
    var patioTemperatureItem = _repository.GetPatioTempById(id);
    return Ok(patioTemperatureItem);
  }

  [HttpGet("last")]
  public ActionResult <PatioTemperature> GetPatioLast()
  {
    var patioTemperatureItem = _repository.GetPatioLast();

    return Ok(patioTemperatureItem);
  }

  [Authorize(Roles = "iot")]
  [HttpPost]
  public ActionResult <PatioTemperature> AddNewTemperatureData(PatioTemperature patioTemperature)
  {
    // var temperatureItem = _repository.AddNewTemperatureData(patioTemperature);
    _repository.AddNewTemperatureData(patioTemperature);
    _repository.SaveChanges();
    return Ok();
  }
  }
}