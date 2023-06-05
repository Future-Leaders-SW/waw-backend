using WAW.API.Subscriptions.Domain.Repositories;
using WAW.API.Subscriptions.Domain.Services;
using WAW.API.Subscriptions.Persistence.Repositories;
using WAW.API.Subscriptions.Services;

namespace WAW.API.Subscriptions.Injection;

public class SubscriptionInjections {

  public static void Register(IServiceCollection services) {
    services.AddScoped<ISubscriptionRepository, SubscriptionRepository>();
    services.AddScoped<ISubscriptionService, SubscriptionService>();
  }

}
