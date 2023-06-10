using WAW.API.Auth.Injection;
using WAW.API.Cvs.Injection;
using WAW.API.Companies.Injection;
using WAW.API.ITProfessionals.Injection;
using WAW.API.Job.Injection;
using WAW.API.Shared.Domain.Repositories;
using WAW.API.Shared.Persistence.Repositories;
using WAW.API.Subscriptions.Injection;

namespace WAW.API.Shared.Injection;

public static class AppInjections {
  public static void Register(IServiceCollection services) {
    AuthInjections.Register(services);
    CompanyInjections.Register(services);
    JobInjections.Register(services);
    SubscriptionInjections.Register(services);
    PlanSubscriptionInjections.Register(services);
    CvInjections.Register(services);
    UbigeoInjections.Register(services);
    ITProfessionalInjections.Register(services);

    services.AddScoped<IUnitOfWork, UnitOfWork>();
  }
}
