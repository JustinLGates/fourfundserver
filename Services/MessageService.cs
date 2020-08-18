using System;
using Repositories;
using Models;
using System.Collections.Generic;

namespace Services
{
  public class MessageService
  {
    private readonly MessageRepo _repo;
    public MessageService(MessageRepo repo)
    {
      _repo = repo;
    }

    internal object Create(Message message)
    {
      return _repo.Create(message);
    }

    internal IEnumerable<Message> Get(string nameIdentifier)
    {
      //TODO ADD CONDITION FOR NAME IDENTIFIER FOR JUST ADMIN ACCOUNTS
      return _repo.Get();
    }
  }

}