using WAW.API.Recruiters.Domain.Repositories;
using WAW.API.Recruiters.Domain.Services;
using WAW.API.Recruiters.Persistence.Repositories;
using WAW.API.Recruiters.Services;

namespace WAW.API.Recruiters.Injection;

public static class RecruiterInjections {

  public static void Register(IServiceCollection services) {
    services.AddScoped<IRecruiterRepository, RecruiterRepository>();
    services.AddScoped<IRecruiterService, RecruiterService>();
  }

}
