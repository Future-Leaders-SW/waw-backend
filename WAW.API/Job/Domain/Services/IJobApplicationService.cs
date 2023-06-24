using WAW.API.Job.Domain.Models;
using WAW.API.Job.Domain.Services.Communication;

namespace WAW.API.Job.Domain.Services;

public interface IJobApplicationService {

  Task<IEnumerable<JobApplication>> ListAll();
  Task<IEnumerable<Offer>> GetOffersByUserId(long userId);

  //Task<IList<JobApplication>> ListByOfferId(long offerId);

  //Task<JobApplication> GetById(long id);

  Task<JobApplicationResponse> Create(JobApplication jobApplication);

  Task<JobApplicationResponse> Update(long id, JobApplication jobApplication);

  Task<JobApplicationResponse> Delete(long id);
}
