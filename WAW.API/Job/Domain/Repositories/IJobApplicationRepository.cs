using WAW.API.Job.Domain.Models;

namespace WAW.API.Job.Domain.Repositories;

public interface IJobApplicationRepository {

  Task<IEnumerable<JobApplication>> ListAll();
  Task Add(JobApplication jobApplication);
  Task<JobApplication?> GetById(long id);
  //Task<IList<JobApplication>> ListByUserId(long userId);
  //Task<IList<JobApplication>> ListByOfferId(long offerId);
  void Update(JobApplication jobApplication);
  void Remove(JobApplication jobApplication); 
}
