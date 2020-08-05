using System.Data;
using Dapper;
using Models;

namespace Repositories
{
  public class MessageRepo
  {
    private readonly IDbConnection _db;

    public MessageRepo(IDbConnection db)
    {
      _db = db;
    }


    internal Message Create(Message MessageData)
    {
      string sql = @"
        INSERT INTO Messages
            (name, body, email,phonenumber)
            VALUES
            (@Name, @Body, @Email, @PhoneNumber);
            SELECT LAST_INSERT_ID();
            ";
      int id = _db.ExecuteScalar<int>(sql, MessageData);
      MessageData.Id = id;
      return MessageData;
    }



  }
}