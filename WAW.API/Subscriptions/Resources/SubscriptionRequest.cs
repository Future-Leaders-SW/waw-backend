using System.ComponentModel.DataAnnotations;
using Swashbuckle.AspNetCore.Annotations;

namespace WAW.API.Subscriptions.Resources;

public class SubscriptionRequest {


  [SwaggerSchema("Subscription planName", Nullable = false)]
  [Required]
  public string? NamePlan { get; set; }

  [SwaggerSchema("Subscription description", Nullable = false)]
  public string Description { get; set; } = string.Empty;

  [SwaggerSchema("Subscription duration", Nullable = false)]
  [Required]
  public int Duration { get; set; }

  [SwaggerSchema("Subscription cost", Nullable = false)]
  [Required]
  public float Cost{ get; set; }

}
