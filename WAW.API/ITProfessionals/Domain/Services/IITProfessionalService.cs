using WAW.API.ITProfessionals.Domain.Models;
using WAW.API.ITProfessionals.Domain.Services.Communication;

namespace WAW.API.ITProfessionals.Domain.Services;

public interface IITProfessionalService {

  Task<IEnumerable<ITProfessional>> ListAll();

  Task<ITProfessionalResponse> Create(ITProfessional itProfessional);

  Task<ITProfessionalResponse> Update(long id, ITProfessional itProfessional);

  Task<ITProfessionalResponse> Delete(long id);

}
