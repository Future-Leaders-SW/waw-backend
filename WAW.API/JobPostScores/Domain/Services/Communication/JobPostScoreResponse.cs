using WAW.API.JobPostScores.Domain.Models;
using WAW.API.Shared.Domain.Service.Communication;

namespace WAW.API.JobPostScores.Domain.Services.Communication;

public class JobPostScoreResponse :BaseResponse<JobPostScore>{
  public JobPostScoreResponse(string message): base(message) { }
  public JobPostScoreResponse(JobPostScore resource): base(resource) { }

}
