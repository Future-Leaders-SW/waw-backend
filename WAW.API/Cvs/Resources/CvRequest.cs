using System.ComponentModel.DataAnnotations;
using Swashbuckle.AspNetCore.Annotations;

namespace WAW.API.Cvs.Resources;

public class CvRequest {
  
  [SwaggerSchema("Title of the CV", Nullable = false)]
  [Required]
  public string? Title { get; set; }
  
  [SwaggerSchema("Cv data", Nullable = false)]
  [Required]
  public byte[]? Data { get; set; }
  
  [SwaggerSchema("Cv extract", Nullable = false)]
  [Required]
  public string? Extract { get; set; }
}
