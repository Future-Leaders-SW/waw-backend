using AutoMapper;
using WAW.API.Cvs.Domain.Models;
using WAW.API.Cvs.Resources;
namespace WAW.API.Cvs.Mapping;

public class DetailResourceToCvProfile {
  public static void Register(IProfileExpression profile)
  {
    profile.CreateMap<Cv, CvCreateModel>();
  }
}
