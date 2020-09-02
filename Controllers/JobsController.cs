using System;
using System.Collections.Generic;
using contractorsfireside.Models;
using contractorsfireside.Services;
using Microsoft.AspNetCore.Mvc;

namespace contractorsfireside.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class JobsController : ControllerBase
  {
    private readonly JobsService _js;
    private readonly BidsService _bs;
    public JobsController(JobsService js, BidsService bs)
    {
      _js = js;
      _bs = bs;
    }

    [HttpGet("{id}/bids")]
    public ActionResult<BidViewModel> GetBidsByJobId(int id)
    {
      try
      {
        return Ok(_bs.GetBidsByJobId(id));
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }


    [HttpGet]
    public ActionResult<IEnumerable<Job>> Get()
    {
      try
      {
        return Ok(_js.Get());
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpGet("{id}")]
    public ActionResult<Job> Get(int id)
    {
      try
      {
        return Ok(_js.Get(id));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }



    [HttpPost]
    public ActionResult<Job> Create([FromBody] Job newJob)
    {
      try
      {
        return Ok(_js.Create(newJob));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }



    [HttpDelete("{id}")]
    public ActionResult<string> Delete(int id)
    {
      try
      {
        return Ok(_js.Delete(id));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

  }
}