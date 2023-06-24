using WAW.API.Auth.Domain.Models;
using WAW.API.Cvs.Domain.Models;
using WAW.API.Job.Domain.Models;
using WAW.API.Shared.Domain.Model;

namespace WAW.API.JobPostScores.Domain.Models;

public class JobPostScore :BaseModel{

  public long? UserId { get; set; }
  public User? User { get; set; }
  public long JobOfferId { get; set; }
  public Offer? JobOffer { get; set; }
  public double Score { get; set; }
}
