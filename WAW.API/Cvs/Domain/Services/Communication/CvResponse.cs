using WAW.API.Cvs.Domain.Models;
using WAW.API.Shared.Domain.Service.Communication;

namespace WAW.API.Cvs.Domain.Services.Communication;

public class CvResponse : BaseResponse<Cv> {
  public CvResponse(string message) : base(message) {}
  public CvResponse(Cv resource) : base(resource) {}
}
