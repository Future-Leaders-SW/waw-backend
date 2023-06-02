using System.ComponentModel.DataAnnotations;
using Swashbuckle.AspNetCore.Annotations;

namespace WAW.API.Cvs.Resources;

public class CvRequest {
  
  [SwaggerSchema("Cv data", Nullable = false)]
  [Required]
  public byte[]? Data { get; set; }
}
