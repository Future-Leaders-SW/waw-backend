using WAW.API.Cvs.Domain.Models;
using WAW.API.Job.Domain.Models;
using WAW.API.Shared.Domain.Model;

namespace WAW.API.JobPostScores.Domain.Models;

public class JobPostScore :BaseModel{
  public Cv? Cv { get; set; }
  public long CvId { get; set; }
  public Offer JobOffer { get; set; } = null!;
  public long JobOfferId { get; set; }
  public double Score { get; set; }
}
