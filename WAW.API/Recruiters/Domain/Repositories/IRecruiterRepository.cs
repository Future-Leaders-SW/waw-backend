using WAW.API.Recruiters.Domain.Models;

namespace WAW.API.Recruiters.Domain.Repositories;

public interface IRecruiterRepository {

  Task<IEnumerable<Recruiter>> ListAll();

  Task Add(Recruiter recruiter);

  Task<Recruiter?> FindById(long id);

  void Update(Recruiter recruiter);

  void Remove(Recruiter recruiter);

}
