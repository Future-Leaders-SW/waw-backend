using Swashbuckle.AspNetCore.Annotations;

namespace WAW.API.Cvs.Resources;

public class CvResource {
  [SwaggerSchema("Cv identifier", ReadOnly = true)]
  public long Id { get; set; }
  
  [SwaggerSchema("Title of the CV", Nullable = false)]
  public string? Title { get; set; }

  [SwaggerSchema("Cv data", Nullable = false)]
  public byte[]? Data { get; set; }
  
  [SwaggerSchema("Cv extract", Nullable = false)]
  public string? Extract { get; set; }
}
