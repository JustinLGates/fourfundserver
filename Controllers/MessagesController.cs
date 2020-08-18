using System;
using System.Collections.Generic;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models;
using Services;

namespace Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class MessagesController : ControllerBase
  {
    private readonly MessageService _MessageService;
    public MessagesController(MessageService messageService)
    {
      _MessageService = messageService;
    }
    // NOTE AVALABLE TO ANY ONE THAT WANTS MORE INFORMATION
    [HttpPost]
    public ActionResult<Message> Create([FromBody] Message message)
    {
      try
      {
        return Ok(_MessageService.Create(message));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    //  NOTE FOR ADMIN USE ONLY NO PUBLIC ACCESS ALLOWED
    [Authorize]
    [HttpGet]
    public ActionResult<IEnumerable<Message>> Get()
    {
      try
      {
        var nameIdentifier = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
        if (nameIdentifier != null)
        {
          return Ok(_MessageService.Get(nameIdentifier));
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