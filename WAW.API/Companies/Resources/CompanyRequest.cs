using System.ComponentModel.DataAnnotations;
using Swashbuckle.AspNetCore.Annotations;

namespace WAW.API.Companies.Resources;

public class CompanyRequest {
  [SwaggerSchema("Category name")]
  [Required]
  public string Name { get; set; } = string.Empty;

}
