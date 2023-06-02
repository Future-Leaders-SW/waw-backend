using WAW.API.Shared.Domain.Model;

namespace WAW.API.Subscriptions.Domain.Models;

public class Subscription :BaseModel{
  public string NamePlan { get; set; }
  public DateTime StartDate { get; set; }
  public DateTime EndDate { get; set; }
  public string Description { get; set; } = string.Empty;

}
