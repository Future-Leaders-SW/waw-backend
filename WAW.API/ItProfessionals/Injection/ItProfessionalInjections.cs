using WAW.API.ItProfessionals.Domain.Repositories;
using WAW.API.ItProfessionals.Domain.Services;
using WAW.API.ItProfessionals.Persistence.Repositories;
using WAW.API.ItProfessionals.Services;

namespace WAW.API.ItProfessionals.Injection;

public static class ItProfessionalInjections {

  public static void Register(IServiceCollection services) {
    services.AddScoped<IItProfessionalRepository, ItProfessionalRepository>();
    services.AddScoped<IItProfessionalService, ItProfessionalService>();
  }

}
