using System;
using System.Collections.Generic;
using System.Security.Claims;
using fourfundserver.Models;
using fourfundserver.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class OffersController : ControllerBase
  {

    private readonly OfferService _OfferService;

    public OffersController(OfferService OfferService)
    {
      _OfferService = OfferService;
    }

    [HttpPost]
    public ActionResult<Offer> Create([FromBody] Offer offer)
    {
      try
      {
        offer.CreatorEmail = "testemail...";
        offer.Orgname = "testorgname";
        return Ok(_OfferService.Create(offer));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    [HttpGet]
    public ActionResult<IEnumerable<Offer>> Get()
    {
      try
      {


        //TODO ADD USER EMAIL/ AUTH CHECK ONLY RETURNOffer TO STAFF
        return Ok(_OfferService.Get("testemail..."));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
  }
}