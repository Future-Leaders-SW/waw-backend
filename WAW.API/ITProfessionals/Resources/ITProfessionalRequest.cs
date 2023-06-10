using System.ComponentModel.DataAnnotations;
using Swashbuckle.AspNetCore.Annotations;

namespace WAW.API.ITProfessionals.Resources;

public class ITProfessionalRequest {


  [SwaggerSchema("ITProfessional Id", Nullable = false)]
  [Required]
  public string? ITProfessionalId { get; set; }

  //Todo revisar si es String, lo mismo en subscriptionPlan
  [SwaggerSchema("ITProfessional User Id", Nullable = false)]
  [Required]
  public string? UserId { get; set; }

  [SwaggerSchema("ITProfessional Cv Id", Nullable = false)]
  [Required]
  public string? CvId { get; set; }

}
