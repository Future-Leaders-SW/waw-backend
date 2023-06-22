using System.ComponentModel.DataAnnotations;
using Swashbuckle.AspNetCore.Annotations;

namespace WAW.API.Shared.Resources;

public class UbigeoRequest {

  [SwaggerSchema("Ubigeo departamento", Nullable = true)]
  [Required]
  public string? Departamento { get; set; } 

  [SwaggerSchema("Ubigeo provincia", Nullable = true)]
  [Required]
  public string? Provincia { get; set; } 

  [SwaggerSchema("Ubigeo distrito", Nullable = true)]
  [Required]
  public string? Distrito { get; set; } 

}
