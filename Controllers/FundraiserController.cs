
using System;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models;
using Services;

namespace Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class FundraiserController : ControllerBase
  {
    private readonly FundraiserService _FundraiserService;

    public FundraiserController(FundraiserService FundraiserService)
    {
      _FundraiserService = FundraiserService;
    }

    [HttpPost]
    public ActionResult<Fundraiser> Create([FromBody] Fundraiser Fundraiser)
    {
      try
      {
        return Ok(_FundraiserService.Create(Fundraiser));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    //TODO IMPLEMENT AUTH CHECK DONT TRUST THE CLIENT
    [HttpGet("{id}")]
    public ActionResult<Fundraiser> Get(int id)
    {
      try
      {
        return Ok(_FundraiserService.Get(id));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
  }
}