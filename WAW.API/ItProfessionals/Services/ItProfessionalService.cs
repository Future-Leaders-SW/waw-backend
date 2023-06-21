using WAW.API.Auth.Domain.Services;
using WAW.API.ItProfessionals.Domain.Models;
using WAW.API.ItProfessionals.Domain.Repositories;
using WAW.API.ItProfessionals.Domain.Services;
using WAW.API.ItProfessionals.Domain.Services.Communication;
using WAW.API.Shared.Domain.Repositories;

namespace WAW.API.ItProfessionals.Services;

public class ItProfessionalService :IItProfessionalService{

  private readonly IItProfessionalRepository repository;
  private IUserService userService;
  private readonly IUnitOfWork unitOfWork;

  public ItProfessionalService(IItProfessionalRepository repository,IUserService userService, IUnitOfWork unitOfWork) {
    this.repository = repository;
    this.userService = userService;
    this.unitOfWork = unitOfWork;
  }

  public Task<IEnumerable<ItProfessional>> ListAll() {
    throw new NotImplementedException();
  }

  public Task<ItProfessionalResponse> Create(ItProfessional itProfessional) {
    //Todo logica del UserService
    //userService.Register()
    throw new NotImplementedException();
  }

  public Task<ItProfessionalResponse> Update(long id, ItProfessional itProfessional) {
    throw new NotImplementedException();
  }

  public Task<ItProfessionalResponse> Delete(long id) {
    throw new NotImplementedException();
  }
}
