using WAW.API.ItProfessionals.Domain.Models;
using WAW.API.Shared.Domain.Service.Communication;

namespace WAW.API.ItProfessionals.Domain.Services.Communication;

public class ItProfessionalResponse :BaseResponse<ItProfessional>{

  public ItProfessionalResponse(string message): base(message) { }
  public ItProfessionalResponse(ItProfessional resource): base(resource) { }
}
