using System.Collections.Generic;
using fourfundserver.Models;
using fourfundserver.Repositories;

namespace fourfundserver.Services
{
  public class OfferService
  {
    private readonly OfferRepo _repo;
    public OfferService(OfferRepo repo)
    {
      _repo = repo;
    }

    internal object Create(Offer offer)
    {
      return _repo.Create(offer);
    }

    internal IEnumerable<Offer> Get(string email)
    {
      return _repo.Get(email);
    }
  }

}
