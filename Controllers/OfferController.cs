using System;
using System.Collections.Generic;
using System.Security.Claims;
using fourfundserver.Models;
using fourfundserver.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models;
using Services;

namespace Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class OffersController : ControllerBase
  {
    private readonly OfferService _OfferService;
    private readonly AdvertiserService _AdvertiserService;
    public OffersController(OfferService OfferService, AdvertiserService advertiserService)
    {
      _OfferService = OfferService;
      _AdvertiserService = advertiserService;
    }
    [Authorize]
    [HttpPost]
    public ActionResult<Offer> Create([FromBody] Offer offer)
    {
      try
      {
        offer.CreatorEmail = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
        Advertiser advertiser = _AdvertiserService.Get(offer.CreatorEmail);
        offer.Logo = advertiser.Logo;
        offer.Orgname = advertiser.OrgName;
        offer.Website = advertiser.Website;
        offer.OrgLocation = advertiser.Location;
        return Ok(_OfferService.Create(offer));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    [Authorize]
    [HttpGet]
    public ActionResult<IEnumerable<Offer>> GetByAdvertiser()
    {
      try
      {
        string email = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
        return Ok(_OfferService.GetByAdvertiser(email));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpGet("/public")]
    public ActionResult<IEnumerable<Offer>> GetPublic()
    {
      try
      {
        return Ok(_OfferService.GetPublic());
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
  }
}