using System.ComponentModel.DataAnnotations;
using Swashbuckle.AspNetCore.Annotations;

namespace WAW.API.ITProfessionals.Resources;

public class ITProfessionalRequest {

  [SwaggerSchema("ITProfessional User Id", Nullable = false)]
  [Required]
  public long UserId { get; set; }

  [SwaggerSchema("ITProfessional Cv Id", Nullable = false)]
  [Required]
  public long CvId { get; set; }

}
