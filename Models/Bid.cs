namespace contractorsfireside.Models
{
  public class Bid
  {
    public int Id { get; set; }
    public int JobId { get; set; }
    public int ContractorId { get; set; }
    public int Price { get; set; }

  }


  public class BidViewModel : Bid
  {
    public string ContractorName { get; set; }
    public string JobName { get; set; }

  }

}