using System.ComponentModel.DataAnnotations;
using Swashbuckle.AspNetCore.Annotations;

namespace WAW.API.Cvs.Resources;

public class CvRequest {
  [SwaggerSchema("Cv title", Nullable = false)]
  [Required]
  public string Title { get; set; } = string.Empty;
  [SwaggerSchema("Cv data", Nullable = false)]
  [Required]
  public byte[] Data { get; set; }
}
