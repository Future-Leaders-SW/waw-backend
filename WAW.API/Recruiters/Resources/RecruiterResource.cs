using System.ComponentModel.DataAnnotations;
using Swashbuckle.AspNetCore.Annotations;

namespace WAW.API.Recruiters.Resources;

public class RecruiterResource {

  [SwaggerSchema("Recruiter Identifier", ReadOnly = true)]
  public long Id { get; set; }

  [SwaggerSchema("Recruiter User Id", Nullable = false)]
  public long UserId { get; set; }

  [SwaggerSchema("Recruiter Company Id", Nullable = false)]
  public long CompanyId { get; set; }
}
