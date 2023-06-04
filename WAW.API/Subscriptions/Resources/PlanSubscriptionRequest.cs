using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;

namespace WAW.API.Subscriptions.Resources;

public class PlanSubscriptionRequest {

  [SwaggerSchema("SubscriptionPlan Subscription Id", Nullable = false)]
  [Required]
  public string? SubscriptionId { get; set; }

  [SwaggerSchema("SubscriptionPlan User Id", Nullable = false)]
  [Required]
  public string? UserId { get; set; }

  [SwaggerSchema("SubscriptionPlan start date", Nullable = false)]
  [Required]
  public DateTime StartDate { get; set; }

  [SwaggerSchema("SubscriptionPlan end date", Nullable = false)]
  [Required]
  public DateTime EndDate { get; set; }

  [SwaggerSchema("SubscriptionPlan payed amount", Nullable = false)]
  [Required]
  public float PayedAmount { get; set; }

  [SwaggerSchema("SubscriptionPlan payed date", Nullable = false)]
  [Required]
  public DateTime PayedDate { get; set; }


}
