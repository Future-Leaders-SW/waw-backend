using System.ComponentModel.DataAnnotations;
using Swashbuckle.AspNetCore.Annotations;

namespace WAW.API.JobPostScores.Resources;

public class JobPostScoreRequest {
  [SwaggerSchema("JobPostScore job offer id", Nullable = false)]
  [Required]
  public long JobOfferId { get; set; }

  [SwaggerSchema("JobPostScore it professional id", Nullable = false)]
  [Required]
  public long ItProfessionalId { get; set; }
}
