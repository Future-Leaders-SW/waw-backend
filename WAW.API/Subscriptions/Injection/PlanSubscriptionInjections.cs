using WAW.API.Subscriptions.Domain.Repositories;
using WAW.API.Subscriptions.Domain.Services;
using WAW.API.Subscriptions.Persistence.Repositories;
using WAW.API.Subscriptions.Services;

namespace WAW.API.Subscriptions.Injection;

public class PlanSubscriptionInjections {

  public static void Register(IServiceCollection services) {
    services.AddScoped<IPlanSubscriptionRepository, PlanSubscriptionRepository>();
    services.AddScoped<IPlanSubscriptionService, PlanSubscriptionService>();
  }
}
