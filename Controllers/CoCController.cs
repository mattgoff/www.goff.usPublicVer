using System;
using www.goff.us.Data;
using www.goff.us.Models;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace www.goff.us.Controllers
{
  [Route("api/coc")]
  [ApiController]

  public class CoCController : ControllerBase
  {
    private readonly ICoCRepo _repository;

    public CoCController(ICoCRepo repository)
    {
      _repository = repository;
    }

  [HttpGet]
  public ActionResult <IEnumerable<CoCPlayer>> GetCoCPlayers()
  {
    var CoCPlayers = _repository.GetCoCPlayers();
    return Ok(CoCPlayers);
  }

  [HttpGet("{id}")]
  public ActionResult <CoCPlayer> GetCoCPlayerById(string id)
  {
    var playerData = _repository.GetCoCPlayerById(id);
    return Ok(playerData);
  }

  [Authorize(Roles = "iot")]
  [HttpPost]
  public ActionResult <CoCPlayer> SetNewPlayer(CoCPlayer coCPlayer)
  {
    _repository.SetCoCData(coCPlayer);
    _repository.SaveChanges();
    return Ok();
  }
  }
}