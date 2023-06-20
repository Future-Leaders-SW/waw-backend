using WAW.API.Recruiters.Domain.Models;
using WAW.API.Recruiters.Domain.Repositories;
using WAW.API.Recruiters.Domain.Services;
using WAW.API.Recruiters.Domain.Services.Communication;
using WAW.API.Shared.Domain.Repositories;

namespace WAW.API.Recruiters.Services;

public class RecruiterService :IRecruiterService {
  private readonly IRecruiterRepository repository;
  private readonly IUnitOfWork unitOfWork;

  public RecruiterService(IRecruiterRepository repository, IUnitOfWork unitOfWork) {
    this.repository = repository;
    this.unitOfWork = unitOfWork;
  }

  public Task<IEnumerable<Recruiter>> ListAll() {
    return repository.ListAll();
  }

  public async Task<RecruiterResponse> Create(Recruiter recruiter) {
    try {
      await repository.Add(recruiter);
      await unitOfWork.Complete();
      return new RecruiterResponse(recruiter);

    } catch (Exception e) {
      return new RecruiterResponse($"An error occurred while saving the Recruiter: {e.Message}");
    }
  }

  public async Task<RecruiterResponse> Update(long id, Recruiter recruiter) {
    var current = await repository.FindById(id);
    if (current == null) return new RecruiterResponse("Recruiter not found");

    recruiter.CopyTo(current);

    try {
      repository.Update(current);
      await unitOfWork.Complete();
      return new RecruiterResponse(recruiter);

    } catch (Exception e) {
      return new RecruiterResponse($"An error occurred while updating the Recruiter: {e.Message}");
    }
  }

  public async Task<RecruiterResponse> Delete(long id) {
    var current = await repository.FindById(id);
    if (current == null) {
      return new RecruiterResponse("Recruiter not found");
    }

    try {
      repository.Remove(current);
      await unitOfWork.Complete();
      return new RecruiterResponse(current);

    } catch (Exception e) {
      return new RecruiterResponse($"An error occurred while deleting the Recruiter: {e.Message}");
    }
  }
}
