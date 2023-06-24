using AutoMapper;
using WAW.API.Auth.Resources;
using WAW.API.Job.Resources;
using WAW.API.JobPostScores.Domain.Models;
using WAW.API.JobPostScores.Resources;

namespace WAW.API.JobPostScores.Mapping;

public static class JobPostScoreModelToResource {
  public static void Register(IProfileExpression profile) {
    profile.CreateMap<JobPostScore, JobPostScoreResource>()
      .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => new UserResource { Id = src.UserId ?? 0 }))
      .ForMember(dest => dest.OfferId, opt => opt.MapFrom(src => new OfferResource { Id = src.OfferId ?? 0 }));
  }
}
