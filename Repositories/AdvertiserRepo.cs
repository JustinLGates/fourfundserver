using System.Data;
using Dapper;
using Models;

namespace Repositories
{
  public class AdvertiserRepo
  {
    private readonly IDbConnection _db;
    public AdvertiserRepo(IDbConnection db)
    {
      _db = db;
    }
    internal Advertiser Create(Advertiser AdvertiserData)
    {
      string sql = @"
        INSERT INTO useradvertiser
            (username, orgname, email, phonenumber,logo)
            VALUES
            (@UserName, @OrgName, @Email, @PhoneNumber,@Logo);
            SELECT LAST_INSERT_ID();
            ";
      int id = _db.ExecuteScalar<int>(sql, AdvertiserData);
      AdvertiserData.Id = id;
      return AdvertiserData;
    }

    internal Advertiser Get(int id)
    {
      string sql = "SELECT * FROM useradvertiser WHERE id = @id";
      return _db.QueryFirstOrDefault<Advertiser>(sql, new { id });
    }
  }
}

