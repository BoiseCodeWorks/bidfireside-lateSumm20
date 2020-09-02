using System;
using System.Collections.Generic;
using contractorsfireside.Models;
using contractorsfireside.Repositories;

namespace contractorsfireside.Services
{
  public class BidsService
  {
    private readonly BidsRepository _repo;

    public BidsService(BidsRepository repo)
    {
      _repo = repo;
    }

    internal string Create(Bid newBid)
    {
      _repo.Create(newBid);
      return "Bid Created";
    }

    internal IEnumerable<BidViewModel> GetBidsByJobId(int id)
    {
      return _repo.GetBidsByJobId(id);
    }
  }
}