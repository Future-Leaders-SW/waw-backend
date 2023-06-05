using WAW.API.Shared.Domain.Model;

namespace WAW.API.Subscriptions.Domain.Models;

public class Subscription :BaseModel{
  public string? NamePlan { get; set; }
  public string Description { get; set; } = string.Empty;
  public int Duration { get; set; }
  public float Cost { get; set; }
  public string Items { get; set; } = string.Empty;

  public IList<PlanSubscription> PlanSubscriptions { get; set; } = null!;
}
