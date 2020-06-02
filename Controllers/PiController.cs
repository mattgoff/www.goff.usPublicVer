using System;
using www.goff.us.Data;
using www.goff.us.Models;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace www.goff.us.Controllers
{
  [Route("api/pi")]
  [ApiController]

  public class PiController : ControllerBase
  {
    private readonly IPiRepo _repository;


    public PiController(IPiRepo repository)
    {
      _repository = repository;
    }

    [HttpGet]
    public ActionResult <PiData> GetLatestPiData()
    {
      var piData = _repository.GetLatestPiData();
      return Ok(piData);
    }

    [HttpGet("all")]
    public ActionResult <IEnumerable<PiData>> GetPiDatas()
    {
      var piData = _repository.GetPiDatas();
      return Ok(piData);
    }

    [Authorize(Roles = "iot")]
    [HttpPost]
      public ActionResult <PiData> SetPiData(PiData piData)
      {
        _repository.SetPiData(piData);
        _repository.SaveChanges();
        return Ok();
      }
  }
}