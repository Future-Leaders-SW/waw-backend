using AutoMapper;
using WAW.API.ItProfessionals.Domain.Models;
using WAW.API.ItProfessionals.Resources;


namespace WAW.API.ItProfessionals.Mapping;

public class ItProfessionalModelToResource {
  public static void Register(IProfileExpression profile) {
    profile.CreateMap<ItProfessional, ItProfessionalResource>();
  }
}
