using WAW.API.Job.Domain.Repositories;
using WAW.API.Job.Domain.Services;
using WAW.API.Job.Persistence.Repositories;
using WAW.API.Job.Services;

namespace WAW.API.Job.Injection;

public static class JobInjections {
  public static void Register(IServiceCollection services) {
    services.AddScoped<IOfferRepository, OfferRepository>();
    services.AddScoped<IOfferService, OfferService>();

    services.AddScoped<IJobApplicationRepository, JobApplicationRepository>();
    services.AddScoped<IJobApplicationService, JobApplicationService>();
  }
}
