using AutoMapper;
using WAW.API.Companies.Domain.Models;
using WAW.API.Companies.Resources;

namespace WAW.API.Companies.Mapping;

public static class CompanyModelToResourceProfile {
  public static void Register(IProfileExpression profile) {
    profile.CreateMap<Company, CompanyResource>();
  }
}
