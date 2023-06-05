using WAW.API.Shared.Domain.Service.Communication;
using WAW.API.Subscriptions.Domain.Models;

namespace WAW.API.Subscriptions.Domain.Services.Communication;

public class SubscriptionResponse :BaseResponse<Subscription>{

  public SubscriptionResponse(string message): base(message) { }
  public SubscriptionResponse(Subscription resource): base(resource) { }

}
