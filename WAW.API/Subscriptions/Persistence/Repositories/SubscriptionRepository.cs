using Microsoft.EntityFrameworkCore;
using WAW.API.Shared.Persistence.Contexts;
using WAW.API.Shared.Persistence.Repositories;
using WAW.API.Subscriptions.Domain.Models;
using WAW.API.Subscriptions.Domain.Repositories;

namespace WAW.API.Subscriptions.Persistence.Repositories;

public class SubscriptionRepository :BaseRepository,ISubscriptionRepository {
  public SubscriptionRepository(AppDbContext context) : base(context) {}
  public async Task<IEnumerable<Subscription>> ListAll() {
    return await context.Subscriptions.ToListAsync();
  }

  public async Task Add(Subscription subscription) {
    await context.Subscriptions.AddAsync(subscription);
  }

  public async Task<Subscription?> FindById(long id) {
    return await context.Subscriptions.FindAsync(id);
  }

  public void Update(Subscription subscription) {
    context.Subscriptions.Update(subscription);
  }

  public void Remove(Subscription subscription) {
    context.Subscriptions.Remove(subscription);
  }
}
