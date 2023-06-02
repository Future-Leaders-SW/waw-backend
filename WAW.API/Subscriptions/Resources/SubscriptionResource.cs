using Swashbuckle.AspNetCore.Annotations;

namespace WAW.API.Subscriptions.Resources;

public class SubscriptionResource {

  [SwaggerSchema("Subscriptionidentifier", ReadOnly = true)]
  public long Id { get; set; }

  [SwaggerSchema("Subscription planName", Nullable = false)]
  public string NamePlan { get; set; }

  [SwaggerSchema("Subscription start date", Nullable = false)]
  public DateTime StartDate { get; set; }

  [SwaggerSchema("Subscription end date", Nullable = false)]
  public DateTime EndDate { get; set; }

  [SwaggerSchema("Subscription description", Nullable = false)]
  public string Description { get; set; } = string.Empty;

}
