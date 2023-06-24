using Microsoft.EntityFrameworkCore;
using WAW.API.Job.Domain.Models;
using WAW.API.Job.Domain.Repositories;
using WAW.API.Shared.Persistence.Contexts;
using WAW.API.Shared.Persistence.Repositories;

namespace WAW.API.Job.Persistence.Repositories;

public class JobApplicationRepository : BaseRepository, IJobApplicationRepository {
  public JobApplicationRepository(AppDbContext context) : base(context) { }

  public async Task<IEnumerable<JobApplication>> ListAll() {
    return await context.JobApplications.ToListAsync();
  }
  
  //public async Task<IList<JobApplication>> ListByUserId(long userId) {
  //  return await context.JobApplications
  //    .Include(x => x.User)
  //    .Include(x => x.Offer)
  //    .Where(x => x.User.Id == userId)
  //    .ToListAsync();
  //}
  //public async Task<IList<JobApplication>> ListByOfferId(long offerId) {
  //  return await context.JobApplications
  //    .Include(x => x.User)
  //    .Include(x => x.Offer)
  //    .Where(x => x.Offer.Id == offerId)
  //    .ToListAsync();
  //}
  public async Task Add(JobApplication jobApplication) {
    await context.JobApplications.AddAsync(jobApplication);
  }
  public async Task<JobApplication?> GetById(long id) {
    return await context.JobApplications.FindAsync(id);
  }

  public void Update(JobApplication jobApplication) {
    context.JobApplications.Update(jobApplication);
  }
  public void Remove(JobApplication jobApplication) {
    context.JobApplications.Remove(jobApplication);
  }
  
}
