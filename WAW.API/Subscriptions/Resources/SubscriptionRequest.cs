using System.ComponentModel.DataAnnotations;
using Swashbuckle.AspNetCore.Annotations;
using WAW.API.Auth.Domain.Models;

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

  [SwaggerSchema("Subscription items", Nullable = false)]
  [Required]
  public string Items { get; set; }
  [SwaggerSchema("Subscription user type", Nullable = false)]
  [Required]
  public UserType? SubscriptionType { get; set; }

}
