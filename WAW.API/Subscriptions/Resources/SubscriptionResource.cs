using Swashbuckle.AspNetCore.Annotations;

namespace WAW.API.Subscriptions.Resources;

public class SubscriptionResource {

  [SwaggerSchema("Subscriptionidentifier", ReadOnly = true)]
  public long Id { get; set; }

  [SwaggerSchema("Subscription planName", Nullable = false)]
  public string NamePlan { get; set; } = null!;

  [SwaggerSchema("Subscription description", Nullable = false)]
  public string Description { get; set; } = string.Empty;

  [SwaggerSchema("Subscription duration", Nullable = false)]
  public int Duration { get; set; }

  [SwaggerSchema("Subscription cost", Nullable = false)]
  public float Cost { get; set; }

}
