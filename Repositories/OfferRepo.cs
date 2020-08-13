using System.Collections.Generic;
using System.Data;
using Dapper;
using fourfundserver.Models;

namespace fourfundserver.Repositories
{
  public class OfferRepo
  {
    private readonly IDbConnection _db;

    public OfferRepo(IDbConnection db)
    {
      _db = db;
    }


    internal Offer Create(Offer OfferData)
    {
      string sql = @"
        INSERT INTO Offers
            (creatoremail, orgname, offer,details,experationdate,logo,orglocation)
            VALUES
            (@CreatorEmail,@Orgname, @OfferBody, @Details, @ExperationDate,@LogoUrl,@Location);
            SELECT LAST_INSERT_ID();
            ";
      int id = _db.ExecuteScalar<int>(sql, OfferData);
      OfferData.Id = id;
      return OfferData;
    }

    internal IEnumerable<Offer> Get(string Email)
    {
      string sql = "SELECT * FROM offers WHERE creatoremail = @Email";
      return _db.Query<Offer>(sql, new { Email });
    }
  }
}





