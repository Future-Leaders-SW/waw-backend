using Swashbuckle.AspNetCore.Annotations;

namespace WAW.API.ITProfessionals.Resources;

public class ITProfessionalResource {

  [SwaggerSchema("ItProfessional User Id", Nullable = false)]
  public string? UserId { get; set; }

  [SwaggerSchema("ItProfessional Cv Id", Nullable = false)]
  public string? CvId { get; set; }
}
