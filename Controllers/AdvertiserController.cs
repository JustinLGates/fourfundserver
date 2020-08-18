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
      try
      {
        string nameIdentifier = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
        if (nameIdentifier != null)
        {
          Advertiser.Email = nameIdentifier;
          return Ok(_AdvertiserService.Create(Advertiser));
        }
        else
        {
          throw new UnauthorizedAccessException("Unauthorized");
        }
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    [Authorize]
    [HttpGet]
    public ActionResult<Advertiser> Get()
    {
      try
      {
        string nameIdentifier = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
        if (nameIdentifier != null)
        {
          return Ok(_AdvertiserService.Get(nameIdentifier));
        }
        else
        {
          throw new UnauthorizedAccessException("Unauthorized");
        }
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
  }
}