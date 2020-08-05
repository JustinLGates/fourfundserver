using System;
using Repositories;
using Models;

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
  }
}