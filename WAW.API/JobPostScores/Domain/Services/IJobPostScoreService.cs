using WAW.API.JobPostScores.Domain.Models;
using WAW.API.JobPostScores.Domain.Services.Communication;

namespace WAW.API.JobPostScores.Domain.Services;

public interface IJobPostScoreService {

  Task<IEnumerable<JobPostScore>> ListAll();

  Task<JobPostScoreResponse> Create(JobPostScore subscription);

  Task<JobPostScoreResponse> Update(long id, JobPostScore subscription);

  Task<JobPostScoreResponse> Delete(long id);
}
