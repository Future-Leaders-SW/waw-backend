using Swashbuckle.AspNetCore.Annotations;

namespace WAW.API.Job.Resources;

public class OfferResource {
  [SwaggerSchema("Job offer identifier", Nullable = false,ReadOnly = true)]
  public long Id { get; set; }

  [SwaggerSchema("Job offer title", Nullable = false)]
  public string Title { get; set; } = string.Empty;

  [SwaggerSchema("Job offer image URL", Nullable = true)]
  public string? Image { get; set; }

  [SwaggerSchema("Job offer description", Nullable = false)]
  public string Description { get; set; } = string.Empty;

  [SwaggerSchema("Job offer minimum salary", Nullable = false)]
  public decimal MinSalary { get; set; }

  [SwaggerSchema("Job offer maximum salary", Nullable = false)]
  public decimal MaxSalary { get; set; }

  [SwaggerSchema("Job offer status", Nullable = false)]
  public bool Status { get; set; }
}
