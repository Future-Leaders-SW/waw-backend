using WAW.API.Shared.Domain.Service.Communication;
using WAW.API.Subscriptions.Domain.Models;

namespace WAW.API.Subscriptions.Domain.Services.Communication;

public class PlanSubscriptionResponse :BaseResponse<PlanSubscription>{

  public PlanSubscriptionResponse(string message) : base(message) { }
  public PlanSubscriptionResponse(PlanSubscription resource) : base(resource) { }

}
