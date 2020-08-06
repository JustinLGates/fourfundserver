using Repositories;
using Models;

namespace Services
{
  public class AdvertiserService
  {
    private readonly AdvertiserRepo _advertiserService;

    public AdvertiserService(AdvertiserRepo advertiserService)
    {
      _advertiserService = advertiserService;
    }
    internal Advertiser Create(Advertiser advertiser)
    {
      return _advertiserService.Create(advertiser);
    }

    internal Advertiser Get(int id)
    {
      return _advertiserService.Get(id);
    }
  }
}