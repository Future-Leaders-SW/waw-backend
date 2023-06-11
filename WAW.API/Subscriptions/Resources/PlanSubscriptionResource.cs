using Swashbuckle.AspNetCore.Annotations;

namespace WAW.API.Subscriptions.Resources;

public class PlanSubscriptionResource {

  [SwaggerSchema("SubscriptionPlan identifier", ReadOnly = true)]
  public long Id { get; set; }

  [SwaggerSchema("SubscriptionPlan Subscription Id", Nullable = false)]
  public long SubscriptionId { get; set; }

  [SwaggerSchema("SubscriptionPlan User Id", Nullable = false)]
  public long UserId { get; set; }

  [SwaggerSchema("SubscriptionPlan start date", Nullable = false)]
  public DateTime StartDate { get; set; }

  [SwaggerSchema("SubscriptionPlan end date", Nullable = false)]
  public DateTime EndDate { get; set; }

  [SwaggerSchema("SubscriptionPlan payed amount", Nullable = false)]
  public float PayedAmount { get; set; }

  [SwaggerSchema("SubscriptionPlan payed date", Nullable = false)]
  public DateTime PayedDate { get; set; }

}
