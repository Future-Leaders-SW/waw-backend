using WAW.API.ItProfessionals.Domain.Models;
using WAW.API.ItProfessionals.Domain.Services.Communication;

namespace WAW.API.ItProfessionals.Domain.Services;

public interface IItProfessionalService {

  Task<IEnumerable<ItProfessional>> ListAll();

  Task<ItProfessionalResponse> Create(ItProfessional itProfessional);

  Task<ItProfessionalResponse> Update(long id, ItProfessional itProfessional);

  Task<ItProfessionalResponse> Delete(long id);

}
