using WAW.API.Recruiters.Domain.Models;
using WAW.API.Recruiters.Domain.Services.Communication;

namespace WAW.API.Recruiters.Domain.Services;

public interface IRecruiterService {
  Task<IEnumerable<Recruiter>> ListAll();

  Task<RecruiterResponse> Create(Recruiter recruiter);

  Task<RecruiterResponse> Update(long id, Recruiter recruiter);

  Task<RecruiterResponse> Delete(long id);
}
