using WAW.API.ITProfessionals.Domain.Models;
using WAW.API.Shared.Domain.Service.Communication;

namespace WAW.API.ITProfessionals.Domain.Services.Communication;

public class ITProfessionalResponse :BaseResponse<ITProfessional>{

  public ITProfessionalResponse(string message): base(message) { }
  public ITProfessionalResponse(ITProfessional resource): base(resource) { }
}
