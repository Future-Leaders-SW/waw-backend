using WAW.API.Shared.Domain.Repositories;
using WAW.API.Shared.Domain.Service;
using WAW.API.Shared.Persistence.Repositories;
using WAW.API.Shared.Services;

namespace WAW.API.Shared.Injection;

public class UbigeoInjections {

  public static void Register(IServiceCollection services) {
    services.AddScoped<IUbigeoRepository, UbigeoRepository>();
    services.AddScoped<IUbigeoService, UbigeoService>();
  }


}
