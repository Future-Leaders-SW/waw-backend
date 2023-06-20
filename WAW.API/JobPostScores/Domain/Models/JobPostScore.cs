using WAW.API.ItProfessionals.Domain.Models;
using WAW.API.Job.Domain.Models;
using WAW.API.Shared.Domain.Model;

namespace WAW.API.JobPostScores.Domain.Models;

public class JobPostScore :BaseModel{
  public ItProfessional ItProfessional { get; set; }= null!;
  public long ItProfessionalId { get; set; }
  public Offer JobOffer { get; set; } = null!;
  public long JobOfferId { get; set; }
}
