using AutoMapper;
using WAW.API.JobPostScores.Domain.Models;
using WAW.API.JobPostScores.Resources;

namespace WAW.API.JobPostScores.Mapping;

public class JobPostScoreResourceToModel {
  public static void Register(IProfileExpression profile) {
    profile.CreateMap<JobPostScoreRequest, JobPostScore>();
  }
}
