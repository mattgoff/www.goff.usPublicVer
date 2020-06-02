using System;
using www.goff.us.Data;
using www.goff.us.Models;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace www.goff.us.Controllers
{
  [Route("api/allergy")]
  [ApiController]

  public class AllergyController : ControllerBase
  {
    private readonly IAllergyRepo _repository;

    public AllergyController(IAllergyRepo repository)
    {
      _repository = repository;
    }
    [HttpGet]
    public ActionResult <AllergyData> GetLatestAllergyData()
    {
      var allergyData = _repository.GetLatestAllergyData();
      return Ok(allergyData);
    }

    [HttpGet("all")]
    public ActionResult <IEnumerable<AllergyData>> GetAllergyData()
    {
      var allergyData = _repository.GetAllergyData();
      return Ok(allergyData);
    }

    [Authorize(Roles = "iot")]
    [HttpPost]
    public ActionResult <AllergyData> SetAllergyData(AllergyData allergyData)
    {
      _repository.SetAllergyData(allergyData);
      _repository.SaveChanges();
      return Ok();
    }

  }
}