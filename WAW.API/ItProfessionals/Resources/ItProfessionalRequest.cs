using System.ComponentModel.DataAnnotations;
using Swashbuckle.AspNetCore.Annotations;

namespace WAW.API.ItProfessionals.Resources;

public class ItProfessionalRequest {

  [SwaggerSchema("ItProfessional User Id", Nullable = false)]
  [Required]
  public long UserId { get; set; }

  [SwaggerSchema("ItProfessional Cv Id", Nullable = false)]
  [Required]
  public long CvId { get; set; }

}
