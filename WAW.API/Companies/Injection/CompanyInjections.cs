using WAW.API.Companies.Domain.Repositories;
using WAW.API.Companies.Domain.Services;
using WAW.API.Companies.Persistence.Repositories;
using WAW.API.Companies.Services;

namespace WAW.API.Companies.Injection;

public static class CompanyInjections {
  public static void Register(IServiceCollection services) {
    services.AddScoped<ICompanyRepository, CompanyRepository>();
    services.AddScoped<ICompanyService, CompanyService>();
  }
}
