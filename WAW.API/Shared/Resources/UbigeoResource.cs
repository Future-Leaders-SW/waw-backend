using Swashbuckle.AspNetCore.Annotations;

namespace WAW.API.Shared.Resources;

public class UbigeoResource {

  [SwaggerSchema("Ubigeo identifier", ReadOnly = true)]
  public long Id { get; set; }

  [SwaggerSchema("Ubigeo departamento", Nullable = false)]
  public string Departamento { get; set; } = String.Empty;

  [SwaggerSchema("Ubigeo provincia", Nullable = false)]
  public string Provincia { get; set; } = String.Empty;

  [SwaggerSchema("Ubigeo distrito", Nullable = false)]
  public string Distrito { get; set; } = String.Empty;


}
