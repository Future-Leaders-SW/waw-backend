using AutoMapper;
using WAW.API.Shared.Domain.Model;
using WAW.API.Shared.Resources;

namespace WAW.API.Shared.Mapping;

public class UbigeoResourceToModel {

  public static void Register(IProfileExpression profile) {
    profile.CreateMap<UbigeoRequest, Ubigeo>();
  }
}
