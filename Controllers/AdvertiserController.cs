
using System;
using System.Security.Claims;
using Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models;


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
[Authorize]
    public ActionResult<Advertiser> Create([FromBody] Advertiser Advertiser)
    {
          string nameIdentifier = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
          Advertiser.Email = nameIdentifier;
      try
      {
        return Ok(_AdvertiserService.Create(Advertiser));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [Authorize]
    [HttpGet]
    public ActionResult<Advertiser> Get(int id)
    {
      try
      {
       string nameIdentifier = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
        return Ok(_AdvertiserService.Get(nameIdentifier));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
  }
}