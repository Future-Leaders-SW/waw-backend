using AutoMapper;
using WAW.API.ITProfessionals.Domain.Models;
using WAW.API.ITProfessionals.Resources;


namespace WAW.API.ITProfessionals.Mapping;

public class ITProfessionalModelToResource {
  public static void Register(IProfileExpression profile) {
    profile.CreateMap<ITProfessional, ITProfessionalResource>();
  }
}
