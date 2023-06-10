using WAW.API.ITProfessionals.Domain.Repositories;
using WAW.API.ITProfessionals.Domain.Services;
using WAW.API.ITProfessionals.Persistence.Repositories;
using WAW.API.ITProfessionals.Services;

namespace WAW.API.ITProfessionals.Injection;

public class ITProfessionalInjections {

  public static void Register(IServiceCollection services) {
    services.AddScoped<IITProfessionalRepository, ITProfessionalRepository>();
    services.AddScoped<IITProfessionalService, ITProfessionalService>();
  }

}
