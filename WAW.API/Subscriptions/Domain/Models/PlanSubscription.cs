using WAW.API.Auth.Domain.Models;
using WAW.API.Shared.Domain.Model;

namespace WAW.API.Subscriptions.Domain.Models;

public class PlanSubscription : BaseModel {

  public Subscription? Subscription { get; set; } = null!;
  public long SubscriptionId { get; set; }
  public User? User { get; set; } = null!;
  public long UserId { get; set; }
  public DateTime StartDate { get; set; }
  public DateTime EndDate { get; set; }
  public float PayedAmount { get; set; }
  public DateTime PayedDate { get; set; }

}
