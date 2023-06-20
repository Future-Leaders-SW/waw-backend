using WAW.API.Shared.Domain.Model;

namespace WAW.API.Shared.Domain.Service.Communication;

public class UbigeoResponse :BaseResponse<Ubigeo>{

  public UbigeoResponse(string message) : base(message) {}
  public UbigeoResponse(Ubigeo resource) : base(resource) {}

}
