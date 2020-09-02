using System;
using System.Collections.Generic;
using System.Data;
using contractorsfireside.Models;
using Dapper;

namespace contractorsfireside.Repositories
{
  public class BidsRepository
  {
    private readonly IDbConnection _db;

    public BidsRepository(IDbConnection db)
    {
      _db = db;
    }

    internal void Create(Bid newBid)
    {
      string sql = @"
        INSERT INTO bids
        (contractorId, jobId, price)
        VALUES
        (@ContractorId, @JobId, @Price);
        SELECT LAST_INSERT_ID();";
      _db.ExecuteScalar<int>(sql, newBid);

    }

    internal IEnumerable<BidViewModel> GetBidsByJobId(int id)
    {
      string sql = @"
        SELECT *,
        c.name as contractorName,
        j.name as jobName
        FROM bids b
        INNER JOIN contractors c ON c.id = b.contractorId
        INNER JOIN jobs j ON j.id = b.jobId
        WHERE (jobId = @id)
        ";
      return _db.Query<BidViewModel>(sql, new { id });
    }
  }
}