using Swashbuckle.AspNetCore.Annotations;

namespace WAW.API.Companies.Resources;

public class CompanyResource {
  [SwaggerSchema("Company identifier", ReadOnly = true)]
  public long Id { get; set; }

  [SwaggerSchema("Company name", Nullable = false)]
  public string Name { get; set; } = string.Empty;

}
