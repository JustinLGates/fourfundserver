
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
    [HttpGet]
    public ActionResult<IEnumerable<Message>> Get()
    {
      try
      {
        //TODO ADD USER EMAIL/ AUTH CHECK ONLY RETURN MESSAGE TO STAFF
        return Ok(_MessageService.Get());
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
  }
}