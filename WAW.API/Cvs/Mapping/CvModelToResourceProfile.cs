using AutoMapper;
using WAW.API.Cvs.Domain.Models;
using WAW.API.Cvs.Resources;

namespace WAW.API.Cvs.Mapping;

public static class CvModelToResourceProfile {
  public static void Register(IProfileExpression profile) {
    profile.CreateMap<Cv, CvResource>();
  }
}
