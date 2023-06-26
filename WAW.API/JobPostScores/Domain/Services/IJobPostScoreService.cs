using WAW.API.JobPostScores.Domain.Models;
using WAW.API.JobPostScores.Domain.Services.Communication;

namespace WAW.API.JobPostScores.Domain.Services;

public interface IJobPostScoreService {

  Task<IEnumerable<JobPostScore>> ListAll();
  
  Task<IEnumerable<JobPostScore>> ListAllByUserId(long userId);

  Task<JobPostScoreResponse> Create(JobPostScore jobPostScore);

  Task<JobPostScoreResponse> Update(long id, JobPostScore jobPostScore);

  Task<JobPostScoreResponse> Delete(long id);
}
