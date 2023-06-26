using System.ComponentModel.DataAnnotations;
using Swashbuckle.AspNetCore.Annotations;

namespace WAW.API.JobPostScores.Resources;

public class JobPostScoreRequest {
  [SwaggerSchema("JobPostScore User id", Nullable = false)]
  [Required]
  public long? UserId { get; set; }

  [SwaggerSchema("JobPostScore it Offer id", Nullable = false)]
  [Required]
  public long? OfferId { get; set; }
  
  [SwaggerSchema("JobPostScore score", Nullable = false)]
  [Required]
  public double Score { get; set; }
}
