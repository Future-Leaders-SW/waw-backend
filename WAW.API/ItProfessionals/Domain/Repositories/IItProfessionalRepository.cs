
using WAW.API.ItProfessionals.Domain.Models;

namespace WAW.API.ItProfessionals.Domain.Repositories;

public interface IItProfessionalRepository {

  Task<IEnumerable<ItProfessional>> ListAll();

  Task Add(ItProfessional itProfessional);

  Task<ItProfessional?> FindById(long id);

  void Update(ItProfessional itProfessional);

  void Remove(ItProfessional itProfessional);
}
