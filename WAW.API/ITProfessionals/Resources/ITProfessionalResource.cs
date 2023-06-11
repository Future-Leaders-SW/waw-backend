using Swashbuckle.AspNetCore.Annotations;

namespace WAW.API.ITProfessionals.Resources;

public class ITProfessionalResource {

  [SwaggerSchema("ITProfessional Id", ReadOnly = true)]
  public long ITProfessionalId { get; set; }

  [SwaggerSchema("ItProfessional User Id", Nullable = false)]
  public long UserId { get; set; }

  [SwaggerSchema("ItProfessional Cv Id", Nullable = false)]
  public long CvId { get; set; }
}
