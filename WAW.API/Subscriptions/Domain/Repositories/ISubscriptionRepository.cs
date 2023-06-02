using WAW.API.Subscriptions.Domain.Models;

namespace WAW.API.Subscriptions.Domain.Repositories;

public interface ISubscriptionRepository {

  Task<IEnumerable<Subscription>> ListAll();

  Task Add(Subscription subscription);

  Task<Subscription?> FindById(long id);

  void Update(Subscription subscription);

  void Remove(Subscription subscription);

}
