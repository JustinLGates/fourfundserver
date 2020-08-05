
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
  [Route("api/[contorller]")]
  public class MessagesController : ControllerBase
  {

    private readonly MessageService _MessageService;

    public MessagesController(MessageService messageService)
    {
      _MessageService = messageService;
    }

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
  }
}