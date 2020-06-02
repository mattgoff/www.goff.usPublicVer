using System;
using www.goff.us.Data;
using www.goff.us.Models;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;


namespace www.goff.us.Controllers
{
  [Route("api/humphrey")]
  [ApiController]

  public class HumphreyController : ControllerBase
  {
    private readonly IHumphreyRepo _repository;
    public HumphreyController(IHumphreyRepo repository)
    {
      _repository = repository;
    }

  [HttpGet]
  public ActionResult <IEnumerable<Humphrey>> GetAllHumphreyLaps()
  {
    var HumphreyLaps = _repository.GetAllHumphreyLaps();
    return Ok(HumphreyLaps);
  }

  [Authorize(Roles = "iot")]
  [HttpPost]
  public ActionResult <Humphrey> AddNewLapData(Humphrey humphrey)
  {
    _repository.AddNewLapData(humphrey);
    _repository.SaveChanges();
    return Ok();
  }
  }
}