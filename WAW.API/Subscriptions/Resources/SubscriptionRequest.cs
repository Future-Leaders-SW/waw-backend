using System.ComponentModel.DataAnnotations;
using Swashbuckle.AspNetCore.Annotations;

namespace WAW.API.Subscriptions.Resources;

public class SubscriptionRequest {


  [SwaggerSchema("Subscription planName", Nullable = false)]
  [Required]
  public string NamePlan { get; set; }

  [SwaggerSchema("Subscription start date", Nullable = false)]
  [Required]
  public DateTime StartDate { get; set; }

  [SwaggerSchema("Subscription end date", Nullable = false)]
  [Required]
  public DateTime EndDate { get; set; }

  [SwaggerSchema("Subscription description", Nullable = false)]
  public string Description { get; set; } = string.Empty;
}
