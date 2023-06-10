using WAW.API.Shared.Domain.Model;

namespace WAW.API.Shared.Domain.Repositories;

public interface IUbigeoRepository {

  Task<IEnumerable<Ubigeo>> ListAll();

  Task Add(Ubigeo ubigeo);

  Task<Ubigeo?> FindById(long id);

  void Update(Ubigeo ubigeo);

  void Remove(Ubigeo ubigeo);
}
