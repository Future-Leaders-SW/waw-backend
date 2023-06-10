using WAW.API.ITProfessionals.Domain.Models;

namespace WAW.API.ITProfessionals.Domain.Repositories;

public interface IITProfessionalRepository {

  Task<IEnumerable<ITProfessional>> ListAll();

  Task Add(ITProfessional itProfessional);

  Task<ITProfessional?> FindById(long id);

  void Update(ITProfessional itProfessional);

  void Remove(ITProfessional itProfessional);
}
