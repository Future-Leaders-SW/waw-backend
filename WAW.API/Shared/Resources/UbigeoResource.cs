using Swashbuckle.AspNetCore.Annotations;

namespace WAW.API.Shared.Resources;

public class UbigeoResource {

  [SwaggerSchema("Ubigeo identifier", Nullable = false, ReadOnly = false)]
  public long Id { get; set; }

  [SwaggerSchema("Ubigeo departamento", Nullable = true)]
  public string? Departamento { get; set; }

  [SwaggerSchema("Ubigeo provincia", Nullable = true)]
  public string? Provincia { get; set; } 

  [SwaggerSchema("Ubigeo distrito", Nullable = true)]
  public string? Distrito { get; set; } 


}
