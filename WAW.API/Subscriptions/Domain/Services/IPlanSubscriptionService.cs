using WAW.API.Subscriptions.Domain.Models;
using WAW.API.Subscriptions.Domain.Services.Communication;

namespace WAW.API.Subscriptions.Domain.Services;

public interface IPlanSubscriptionService {

  Task<IEnumerable<PlanSubscription>> ListAll();

  Task<PlanSubscriptionResponse> Create(PlanSubscription planSubscription);

  Task<PlanSubscriptionResponse> Update(long id, PlanSubscription planSubscrition);

  Task<PlanSubscriptionResponse> Delete(long id);

}
