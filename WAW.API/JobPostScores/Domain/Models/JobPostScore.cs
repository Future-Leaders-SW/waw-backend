using WAW.API.ITProfessionals.Domain.Models;
using WAW.API.Job.Domain.Models;
using WAW.API.Shared.Domain.Model;

namespace WAW.API.JobPostScores.Domain.Models;

public class JobPostScore :BaseModel{
  public ITProfessional ITProfessional { get; set; }= null!;
  public long ITProfessionalId { get; set; }
  public Offer JobOffer { get; set; } = null!;
  public long JobOfferId { get; set; }
}
