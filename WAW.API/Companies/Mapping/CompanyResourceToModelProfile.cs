using AutoMapper;
using WAW.API.Companies.Domain.Models;
using WAW.API.Companies.Resources;

namespace WAW.API.Companies.Mapping;

public static class CompanyResourceToModelProfile {
  public static void Register(IProfileExpression profile) {
    profile.CreateMap<CompanyRequest, Company>();
  }
}
