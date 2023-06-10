using WAW.API.Shared.Domain.Model;
using WAW.API.Shared.Domain.Repositories;
using WAW.API.Shared.Domain.Service;
using WAW.API.Shared.Domain.Service.Communication;

namespace WAW.API.Shared.Services;

public class UbigeoService :IUbigeoService{

  private readonly IUbigeoRepository repository;
  private readonly IUnitOfWork unitOfWork;

  public UbigeoService(IUbigeoRepository repository, IUnitOfWork unitOfWork) {
    this.repository = repository;
    this.unitOfWork = unitOfWork;
  }
  public Task<IEnumerable<Ubigeo>> ListAll() {
    return repository.ListAll();
  }

  public async Task<UbigeoResponse> Create(Ubigeo ubigeo) {
    try {
      await repository.Add(ubigeo);
      await unitOfWork.Complete();
      return new UbigeoResponse(ubigeo);
    } catch (Exception e) {
      return new UbigeoResponse($"An error occurred while saving the ubigeo: {e.Message}");
    }
  }

  public async Task<UbigeoResponse> Update(long id, Ubigeo ubigeo) {

    var current = await repository.FindById(id);
    if (current == null) return new UbigeoResponse("Ubigeo not found");
    ubigeo.CopyTo(current);

    try {
      repository.Update(current);
      await unitOfWork.Complete();
      return new UbigeoResponse(ubigeo);
    } catch (Exception e) {
      return new UbigeoResponse($"An error occurred while updating the ubigeo: {e.Message}");
    }
  }

  public async Task<UbigeoResponse> Delete(long id) {

    var current = await repository.FindById(id);
    if(current == null) return new UbigeoResponse("Ubigeo not found");

    try {
      repository.Remove(current);
      await unitOfWork.Complete();
      return new UbigeoResponse(current);
    } catch (Exception e) {
      return new UbigeoResponse($"An error occurred while deleting the ubigeo: {e.Message}");
    }
  }
}
