using Swashbuckle.AspNetCore.Annotations;

namespace WAW.API.JobPostScores.Resources;

public class JobPostScoreResource {
  [SwaggerSchema("JobPostScore Identifier", ReadOnly = true)]
  public long Id { get; set; }

  [SwaggerSchema("JobPostScore job offer id", Nullable = false)]
  public long JobOfferId { get; set; }

  [SwaggerSchema("JobPostScore it professional id", Nullable = false)]
  public long ItProfessionalId { get; set; }
}
