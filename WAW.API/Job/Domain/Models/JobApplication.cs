using WAW.API.Auth.Domain.Models;
using WAW.API.Shared.Domain.Model;
namespace WAW.API.Job.Domain.Models;

public class JobApplication : BaseModel {

  
  public long? UserId { get; set; }
  public User? User { get; set; }
  public long? OfferId { get; set; }
  public Offer? Offer { get; set; }
  public DateTime ApplicationDate { get; set; }
}
