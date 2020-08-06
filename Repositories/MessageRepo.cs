using System;
using System.Data;
using Dapper;
using Models;
using System.Collections.Generic;

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
        INSERT INTO messages
            (username, body, email,phonenumber)
            VALUES
            (@UserName, @Body, @Email, @PhoneNumber);
            SELECT LAST_INSERT_ID();
            ";
      int id = _db.ExecuteScalar<int>(sql, MessageData);
      MessageData.Id = id;
      return MessageData;
    }

    internal IEnumerable<Message> Get()
    {
      string sql = "SELECT * FROM messages";
      return _db.Query<Message>(sql);
    }
  }
}