using AutoMapper;
using WAW.API.Shared.Domain.Model;
using WAW.API.Shared.Resources;

namespace WAW.API.Shared.Mapping;

public class UbigeoModelToResource {
  public static void Register(IProfileExpression profile) {
    profile.CreateMap<Ubigeo, UbigeoResource>();
  }
}
