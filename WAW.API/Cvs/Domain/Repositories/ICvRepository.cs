using WAW.API.Cvs.Domain.Models;

namespace WAW.API.Cvs.Domain.Repositories;

public interface ICvRepository {
  Task<IEnumerable<Cv>> ListAll();

  Task Add(Cv cv);

  Task<Cv?> FindById(long id);

  void Update(Cv offer);

  void Remove(Cv offer);
}
