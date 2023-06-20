using Swashbuckle.AspNetCore.Annotations;

namespace WAW.API.ItProfessionals.Resources;

public class ItProfessionalResource {

  [SwaggerSchema("ItProfessional Id", ReadOnly = true)]
  public long ItProfessionalId { get; set; }

  [SwaggerSchema("ItProfessional User Id", Nullable = false)]
  public long UserId { get; set; }

  [SwaggerSchema("ItProfessional Cv Id", Nullable = false)]
  public long CvId { get; set; }
}
