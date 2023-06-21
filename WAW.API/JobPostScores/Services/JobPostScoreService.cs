using WAW.API.JobPostScores.Domain.Models;
using WAW.API.JobPostScores.Domain.Repositories;
using WAW.API.JobPostScores.Domain.Services;
using WAW.API.JobPostScores.Domain.Services.Communication;
using WAW.API.Shared.Domain.Repositories;

namespace WAW.API.JobPostScores.Services;

public class JobPostScoreService :IJobPostScoreService {

  private readonly IJobPostScoreRepository repository;
  private readonly IUnitOfWork unitOfWork;

  public JobPostScoreService(IJobPostScoreRepository repository, IUnitOfWork unitOfWork) {
    this.repository = repository;
    this.unitOfWork = unitOfWork;
  }

  public Task<IEnumerable<JobPostScore>> ListAll() {
    return repository.ListAll();
  }

  public async Task<JobPostScoreResponse> Create(JobPostScore jobPostScore) {
    try {
      await repository.Add(jobPostScore);
      await unitOfWork.Complete();
      return new JobPostScoreResponse(jobPostScore);

    } catch (Exception e) {
      return new JobPostScoreResponse($"An error occurred while saving the jobPostScore: {e.Message}");
    }
  }

  public async Task<JobPostScoreResponse> Update(long id, JobPostScore jobPostScore) {
    var current = await repository.FindById(id);
    if (current == null) return new JobPostScoreResponse("JobPostScore not found");

    jobPostScore.CopyTo(current);

    try {
      repository.Update(current);
      await unitOfWork.Complete();
      return new JobPostScoreResponse(jobPostScore);

    } catch (Exception e) {
      return new JobPostScoreResponse($"An error occurred while updating the jobPostScore: {e.Message}");
    }
  }

  public async Task<JobPostScoreResponse> Delete(long id) {
    var current = await repository.FindById(id);
    if (current == null) {
      return new JobPostScoreResponse("JobPostScore not found");
    }

    try {
      repository.Remove(current);
      await unitOfWork.Complete();
      return new JobPostScoreResponse(current);

    } catch (Exception e) {
      return new JobPostScoreResponse($"An error occurred while deleting the jobPostScore: {e.Message}");
    }
  }
}
