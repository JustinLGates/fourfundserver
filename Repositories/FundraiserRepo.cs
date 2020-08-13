using System.Data;
using Dapper;
using Models;

namespace Repositories
{
  public class FundraiserRepo
  {
    private readonly IDbConnection _db;
    public FundraiserRepo(IDbConnection db)
    {
      _db = db;
    }
    internal Fundraiser Create(Fundraiser FundraiserData)
    {
      string sql = @"
        INSERT INTO userFundraiser
            (username, orgname, email, phonenumber,logo)
            VALUES
            (@UserName, @OrgName, @Email, @PhoneNumber,@Logo);
            SELECT LAST_INSERT_ID();
            ";
      int id = _db.ExecuteScalar<int>(sql, FundraiserData);
      FundraiserData.Id = id;
      return FundraiserData;
    }

    internal Fundraiser Get(string nameIdentifier)
    {
      string sql = "SELECT * FROM userFundraiser WHERE id = @nameIdentifier";
      return _db.QueryFirstOrDefault<Fundraiser>(sql, new { nameIdentifier });
    }
  }
}