using System;
using www.goff.us.Data;
using www.goff.us.Models;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;


namespace www.goff.us.Controllers
{
  [Route("api/office")]
  [ApiController]

  public class OfficeController : ControllerBase
  {
    private readonly IOfficeRepo _repository;
    public OfficeController(IOfficeRepo repository)
    {
      _repository = repository;
    }

  [HttpGet]
  public ActionResult <IEnumerable<OfficeTemperature>> GetAllOfficeTemps()
  {
    var OfficeTemperatureItems = _repository.GetAllOfficeTemps();
    return Ok(OfficeTemperatureItems);
  }
  [HttpGet("{id}")]
  public ActionResult <OfficeTemperature> GetOfficeTempById(int id)
  {
    var OfficeTemperatureItem = _repository.GetOfficeTempById(id);
    return Ok(OfficeTemperatureItem);
  }

  [HttpGet("last")]
  public ActionResult <OfficeTemperature> GetOfficeLast()
  {
    var OfficeTemperatureItem = _repository.GetOfficeLast();

    return Ok(OfficeTemperatureItem);
  }

  [Authorize(Roles = "iot")]
  [HttpPost]
  public ActionResult <OfficeTemperature> AddNewTemperatureData(OfficeTemperature OfficeTemperature)
  {
    _repository.AddNewTemperatureData(OfficeTemperature);
    _repository.SaveChanges();
    return Ok();
  }
  }
}