using WAW.API.Cvs.Domain.Models;
using WAW.API.Cvs.Domain.Services.Communication;

namespace WAW.API.Cvs.Domain.Services;

public interface ICvService {
  Task<IEnumerable<Cv>> ListAll();
  Task<CvResponse> GetById(long id);
  Task<CvResponse> Create(Cv cv);
  Task<CvResponse> Update(long id, Cv cv);
  Task<CvResponse> Delete(long id);
  Task<string> GetExtractByCvId(long cvId);
}
