using System;
using www.goff.us.Data;
using www.goff.us.Models;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;


namespace www.goff.us.Controllers
{
  [Route("api/frontdoor")]
  [ApiController]

  public class FrontDoorController : ControllerBase
  {
    private readonly IFrontDoorRepo _repository;
    public FrontDoorController(IFrontDoorRepo repository)
    {
      _repository = repository;
    }

  [HttpGet]
  public ActionResult <IEnumerable<FrontDoorTemperature>> GetAllFrontDoorTemps()
  {
    var frontTemperatureItems = _repository.GetAllFrontDoorTemps();
    return Ok(frontTemperatureItems);
  }
  [HttpGet("{id}")]
  public ActionResult <FrontDoorTemperature> GetFrontDoorTempById(int id)
  {
    var frontTemperatureItem = _repository.GetFrontDoorTempById(id);
    return Ok(frontTemperatureItem);
  }

  [HttpGet("last")]
  public ActionResult <FrontDoorTemperature> GetFrontDoorLast()
  {
    var frontTemperatureItem = _repository.GetFrontDoorLast();

    return Ok(frontTemperatureItem);
  }

  [Authorize(Roles = "iot")]
  [HttpPost]
  public ActionResult <FrontDoorTemperature> AddNewTemperatureData(FrontDoorTemperature frontDoorTemperature)
  {
    _repository.AddNewTemperatureData(frontDoorTemperature);
    _repository.SaveChanges();
    return Ok();
  }
  }
}