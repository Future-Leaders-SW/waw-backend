using WAW.API.Shared.Domain.Model;
using WAW.API.Shared.Domain.Service.Communication;

namespace WAW.API.Shared.Domain.Service;

public interface IUbigeoService {

  Task<IEnumerable<Ubigeo>> ListAll();

  Task<UbigeoResponse> Create(Ubigeo subscription);

  Task<UbigeoResponse> Update(long id, Ubigeo subscription);

  Task<UbigeoResponse> Delete(long id);

}
