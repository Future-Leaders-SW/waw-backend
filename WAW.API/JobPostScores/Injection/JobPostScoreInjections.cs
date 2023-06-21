using WAW.API.JobPostScores.Domain.Repositories;
using WAW.API.JobPostScores.Domain.Services;
using WAW.API.JobPostScores.Persistence.Repositories;
using WAW.API.JobPostScores.Services;

namespace WAW.API.JobPostScores.Injection;

public static class JobPostScoreInjections {
  public static void Register(IServiceCollection services) {
    services.AddScoped<IJobPostScoreRepository, JobPostScoreRepository>();
    services.AddScoped<IJobPostScoreService, JobPostScoreService>();
  }
}
