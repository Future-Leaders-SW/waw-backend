using WAW.API.Subscriptions.Domain.Models;
using WAW.API.Subscriptions.Domain.Services.Communication;

namespace WAW.API.Subscriptions.Domain.Services;

public interface ISubscriptionService {
  Task<IEnumerable<Subscription>> ListAll();

  Task<SubscriptionResponse> Create(Subscription subscription);

  Task<SubscriptionResponse> Update(long id, Subscription subscription);

  Task<SubscriptionResponse> Delete(long id);
}
