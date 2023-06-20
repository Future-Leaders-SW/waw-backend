using WAW.API.Companies.Domain.Models;

namespace WAW.API.Companies.Domain.Repositories;

public interface ICompanyRepository {
  Task<IEnumerable<Company>> ListAll();
  Task Add(Company company);
  Task<Company?> FindById(long id);
  Task<Company?> FindByName(string name);
  void Update(Company company);
  void Remove(Company company);
}
