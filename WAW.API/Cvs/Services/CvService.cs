using WAW.API.Cvs.Domain.Models;
using WAW.API.Cvs.Domain.Repositories;
using WAW.API.Cvs.Domain.Services;
using WAW.API.Cvs.Domain.Services.Communication;
using WAW.API.Shared.Domain.Repositories;

namespace WAW.API.Cvs.Services;

public class CvService : ICvService {
  private readonly ICvRepository repository;
  private readonly IUnitOfWork unitOfWork;

  public CvService(ICvRepository repository, IUnitOfWork unitOfWork) {
    this.repository = repository;
    this.unitOfWork = unitOfWork;
  }

  public Task<IEnumerable<Cv>> ListAll() {
    return repository.ListAll();
  }

  public async Task<CvResponse> Create(Cv cv) {
    try {
      await repository.Add(cv);
      await unitOfWork.Complete();
      return new CvResponse(cv);
    } catch (Exception e) {
      return new CvResponse($"An error occurred while saving the cv: {e.Message}");
    }
  }

  public async Task<CvResponse> Update(long id, Cv cv) {
    var current = await repository.FindById(id);
    if (current == null) return new CvResponse("Cv not found");

    cv.CopyTo(current);

    try {
      repository.Update(current);
      await unitOfWork.Complete();
      return new CvResponse(current);
    } catch (Exception e) {
      return new CvResponse($"An error occurred while updating the cv: {e.Message}");
    }
  }

  public async Task<CvResponse> Delete(long id) {
    var current = await repository.FindById(id);
    if (current == null) return new CvResponse("Cv not found");

    try {
      repository.Remove(current);
      await unitOfWork.Complete();
      return new CvResponse(current);
    } catch (Exception e) {
      return new CvResponse($"An error occurred while deleting the cv: {e.Message}");
    }
  }
}
