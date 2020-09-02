using contractorsfireside.Models;
using contractorsfireside.Services;
using Microsoft.AspNetCore.Mvc;

namespace contractorsfireside.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class BidsController : ControllerBase
  {
    private readonly BidsService _bs;

    public BidsController(BidsService bs)
    {
      _bs = bs;
    }


    [HttpPost]
    public ActionResult<Bid> Create([FromBody] Bid newBid)
    {
      try
      {
        return Ok(_bs.Create(newBid));
      }
      catch (System.Exception e)
      {

        return BadRequest(e.Message);
      }
    }

  }
}