using System;
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
        INSERT INTO offers
            (creatoremail, orgname, offer, details, experationdate, logo, orglocation, website)
            VALUES
            (@CreatorEmail, @Orgname, @offer, @Details, @ExperationDate, @Logo, @OrgLocation, @Website);
            SELECT LAST_INSERT_ID();
            ";
      int id = _db.ExecuteScalar<int>(sql, OfferData);
      OfferData.Id = id;
      return OfferData;
    }

    internal IEnumerable<Offer> GetPublic()
    {
      string sql = "SELECT * FROM offers";
      return _db.Query<Offer>(sql);
    }

    internal IEnumerable<Offer> GetByAdvertiser(string Email)
    {
      string sql = "SELECT * FROM offers WHERE creatoremail = @Email";
      return _db.Query<Offer>(sql, new { Email });
    }
  }
}





