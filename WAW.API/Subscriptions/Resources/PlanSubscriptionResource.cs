using Swashbuckle.AspNetCore.Annotations;
using WAW.API.Auth.Domain.Services.Communication;
using WAW.API.Auth.Resources;

namespace WAW.API.Subscriptions.Resources;

public class PlanSubscriptionResource {

  [SwaggerSchema("SubscriptionPlan identifier", ReadOnly = true)]
  public long Id { get; set; }

  [SwaggerSchema("SubscriptionPlan Subscription", Nullable = false)]
  public SubscriptionResource? Subscription { get; set; }

  [SwaggerSchema("SubscriptionPlan User", Nullable = false)]
  public UserResource? User { get; set; }

  [SwaggerSchema("SubscriptionPlan start date", Nullable = false)]
  public DateTime StartDate { get; set; }

  [SwaggerSchema("SubscriptionPlan end date", Nullable = false)]
  public DateTime EndDate { get; set; }

  [SwaggerSchema("SubscriptionPlan payed amount", Nullable = false)]
  public float PayedAmount { get; set; }

  [SwaggerSchema("SubscriptionPlan payed date", Nullable = false)]
  public DateTime PayedDate { get; set; }

}
