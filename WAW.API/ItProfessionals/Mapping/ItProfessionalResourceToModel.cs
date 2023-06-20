using AutoMapper;
using WAW.API.ItProfessionals.Domain.Models;
using WAW.API.ItProfessionals.Resources;

namespace WAW.API.ItProfessionals.Mapping;

public class ItProfessionalResourceToModel {

  public static void Register(IProfileExpression profile) {
    profile.CreateMap<ItProfessionalRequest, ItProfessional>();
  }

}
