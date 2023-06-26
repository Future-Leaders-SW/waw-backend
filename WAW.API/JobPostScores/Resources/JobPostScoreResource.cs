using Swashbuckle.AspNetCore.Annotations;
using WAW.API.Auth.Resources;
using WAW.API.Cvs.Domain.Models;
using WAW.API.Job.Resources;

namespace WAW.API.JobPostScores.Resources;

public class JobPostScoreResource {
  [SwaggerSchema("JobPostScore Identifier", ReadOnly = true)]
  public long Id { get; set; }

  [SwaggerSchema("JobPostScore User id", Nullable = false)]
  public UserResource? UserId { get; set; }

  [SwaggerSchema("JobPostScore it offer id", Nullable = false)]
  public OfferResource? OfferId { get; set; }
  
  [SwaggerSchema("JobPostScore score", Nullable = false)]
  public double Score { get; set; }
}
