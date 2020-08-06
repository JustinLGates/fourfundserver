
using System;
using System.Collections.Generic;
using System.Security.Claims;
using Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models;
using Services;

namespace Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class AdvertiserController : ControllerBase
  {

    private readonly AdvertiserService _AdvertiserService;

    public AdvertiserController(AdvertiserService AdvertiserService)
    {
      _AdvertiserService = AdvertiserService;
    }

    [HttpPost]
    public ActionResult<Advertiser> Create([FromBody] Advertiser Advertiser)
    {
      try
      {
        return Ok(_AdvertiserService.Create(Advertiser));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    //TODO IMPLEMENT AUTH CHECK DONT TRUST THE CLIENT
    [HttpGet("{id}")]
    public ActionResult<Advertiser> Get(int id)
    {
      try
      {
        return Ok(_AdvertiserService.Get(id));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
  }
}