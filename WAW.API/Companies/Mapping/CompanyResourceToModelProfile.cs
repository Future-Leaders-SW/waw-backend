using AutoMapper;
using WAW.API.Companies.Resources;

namespace WAW.API.Companies.Mapping;

using Domain.Models;

public static class CompanyResourceToModelProfile {
  public static void Register(IProfileExpression profile) {
    profile.CreateMap<CompanyRequest, Company>();
  }
}
