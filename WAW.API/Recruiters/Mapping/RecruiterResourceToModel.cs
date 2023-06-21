using AutoMapper;
using WAW.API.Recruiters.Domain.Models;
using WAW.API.Recruiters.Resources;

namespace WAW.API.Recruiters.Mapping;

public class RecruiterResourceToModel {
  public static void Register(IProfileExpression profile) {
    profile.CreateMap<RecruiterRequest, Recruiter>();
  }
}
