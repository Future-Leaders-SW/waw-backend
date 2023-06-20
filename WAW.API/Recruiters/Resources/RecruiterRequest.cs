using System.ComponentModel.DataAnnotations;
using Swashbuckle.AspNetCore.Annotations;

namespace WAW.API.Recruiters.Resources;

public class RecruiterRequest {
  [SwaggerSchema("Recruiter User Id", Nullable = false)]
  [Required]
  public long UserId { get; set; }

  [SwaggerSchema("Recruiter Company Id", Nullable = false)]
  [Required]
  public long CompanyId { get; set; }
}
