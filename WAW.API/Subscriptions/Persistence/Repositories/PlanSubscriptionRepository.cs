using Microsoft.EntityFrameworkCore;
using WAW.API.Shared.Persistence.Contexts;
using WAW.API.Shared.Persistence.Repositories;
using WAW.API.Subscriptions.Domain.Models;
using WAW.API.Subscriptions.Domain.Repositories;

namespace WAW.API.Subscriptions.Persistence.Repositories;

public class PlanSubscriptionRepository : BaseRepository, IPlanSubscriptionRepository {
  public PlanSubscriptionRepository(AppDbContext context) : base(context) {
  }

  public async Task Add(PlanSubscription planSubscription) {
    await context.PlanSubscriptions.AddAsync(planSubscription);
  }

  public Task<PlanSubscription> FindById(long id) {
    return context.PlanSubscriptions.Where(u => u.Id == id)
      .FirstOrDefaultAsync();
  }

  public async Task<List<PlanSubscription>> GetPlanSubscriptionsByUserId(long userId) {
    return await context.PlanSubscriptions
      .Where(ps => ps.UserId == userId)
      .Include(x=>x.Subscription)
      .ToListAsync();
  }

  public async Task<PlanSubscription?> FindBySubscriptionIdAndUserId(long subscriptionId, long userId) {
    return await context.PlanSubscriptions.FindAsync(subscriptionId, userId);
  }

  public async Task<IEnumerable<PlanSubscription>> ListAll() {
    return await context.PlanSubscriptions.ToListAsync();
  }

  public void Remove(PlanSubscription planSubscription) {
    context.PlanSubscriptions.Remove(planSubscription);
  }

  public void Update(PlanSubscription planSubscription) {
    context.PlanSubscriptions.Update(planSubscription);
  }
}
