using WAW.API.Subscriptions.Domain.Models;

namespace WAW.API.Subscriptions.Domain.Repositories;

public interface IPlanSubscriptionRepository {

  Task<IEnumerable<PlanSubscription>> ListAll();

  Task Add(PlanSubscription planSubscription);

  Task<PlanSubscription?> FindBySubscriptionIdAndUserId(long subscriptionId, long userId);

  void Update(PlanSubscription planSubscription);

  void Remove(PlanSubscription planSubscription);

  Task<PlanSubscription> FindById(long id);

  Task<List<PlanSubscription>> GetPlanSubscriptionsByUserId(long userId);

}
