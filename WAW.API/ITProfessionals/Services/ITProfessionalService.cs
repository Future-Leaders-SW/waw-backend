using WAW.API.Auth.Domain.Services;
using WAW.API.ITProfessionals.Domain.Models;
using WAW.API.ITProfessionals.Domain.Repositories;
using WAW.API.ITProfessionals.Domain.Services;
using WAW.API.ITProfessionals.Domain.Services.Communication;
using WAW.API.Shared.Domain.Repositories;

namespace WAW.API.ITProfessionals.Services;

public class ITProfessionalService :IITProfessionalService{

  private readonly IITProfessionalRepository repository;
  private IUserService userService;
  private readonly IUnitOfWork unitOfWork;

  public ITProfessionalService(IITProfessionalRepository repository,IUserService userService, IUnitOfWork unitOfWork) {
    this.repository = repository;
    this.userService = userService;
    this.unitOfWork = unitOfWork;
  }

  public Task<IEnumerable<ITProfessional>> ListAll() {
    throw new NotImplementedException();
  }

  public Task<ITProfessionalResponse> Create(ITProfessional itProfessional) {
    //Todo logica del UserService
    //userService.Register()
    throw new NotImplementedException();
  }

  public Task<ITProfessionalResponse> Update(long id, ITProfessional itProfessional) {
    throw new NotImplementedException();
  }

  public Task<ITProfessionalResponse> Delete(long id) {
    throw new NotImplementedException();
  }
}
