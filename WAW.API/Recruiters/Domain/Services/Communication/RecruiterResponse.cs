using WAW.API.Recruiters.Domain.Models;
using WAW.API.Shared.Domain.Service.Communication;

namespace WAW.API.Recruiters.Domain.Services.Communication;

public class RecruiterResponse : BaseResponse<Recruiter>{

  public RecruiterResponse(string message): base(message) { }
  public RecruiterResponse(Recruiter resource): base(resource) { }

}
