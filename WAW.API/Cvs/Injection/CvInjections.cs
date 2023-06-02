using WAW.API.Cvs.Domain.Repositories;
using WAW.API.Cvs.Domain.Services;
using WAW.API.Cvs.Persistence.Repositories;
using WAW.API.Cvs.Services;

namespace WAW.API.Cvs.Injection;

public static class CvInjections {
  public static void Register(IServiceCollection services) {
    services.AddScoped<ICvRepository, CvRepository>();
    services.AddScoped<ICvService, CvService>();
  }
}
