using WAW.API.JobPostScores.Domain.Models;

namespace WAW.API.JobPostScores.Domain.Repositories;

public interface IJobPostScoreRepository {

  Task<IEnumerable<JobPostScore>> ListAll();
  
  Task<IEnumerable<JobPostScore>> ListAllByUserId(long userId);

  Task Add(JobPostScore jobPostScore);

  Task<JobPostScore?> FindById(long id);

  void Update(JobPostScore jobPostScore);

  void Remove(JobPostScore jobPostScore);
}
