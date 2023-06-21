using System.ComponentModel.DataAnnotations;
using Swashbuckle.AspNetCore.Annotations;

namespace WAW.API.Shared.Resources;

public class UbigeoRequest {

  [SwaggerSchema("Ubigeo departamento", Nullable = false)]
  [Required]
  public string Departamento { get; set; } = String.Empty;

  [SwaggerSchema("Ubigeo provincia", Nullable = false)]
  [Required]
  public string Provincia { get; set; } = String.Empty;

  [SwaggerSchema("Ubigeo distrito", Nullable = false)]
  [Required]
  public string Distrito { get; set; } = String.Empty;

}
