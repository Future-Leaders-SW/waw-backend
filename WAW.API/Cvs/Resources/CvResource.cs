using Swashbuckle.AspNetCore.Annotations;

namespace WAW.API.Cvs.Resources;

public class CvResource {
  [SwaggerSchema("Cv identifier", ReadOnly = true)]
  public long Id { get; set; }

  [SwaggerSchema("Cv data", Nullable = false)]
  public byte[]? Data { get; set; }
}
