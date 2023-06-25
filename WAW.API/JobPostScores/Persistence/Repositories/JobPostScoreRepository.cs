using Microsoft.EntityFrameworkCore;
using WAW.API.JobPostScores.Domain.Models;
using WAW.API.JobPostScores.Domain.Repositories;
using WAW.API.Shared.Persistence.Contexts;
using WAW.API.Shared.Persistence.Repositories;

namespace WAW.API.JobPostScores.Persistence.Repositories;

public class JobPostScoreRepository :BaseRepository,IJobPostScoreRepository {
  public JobPostScoreRepository(AppDbContext context) : base(context) {}
  public async Task<IEnumerable<JobPostScore>> ListAll() {
    return await context.JobPostScores.ToListAsync();
  }
  
  public async Task<IEnumerable<JobPostScore>> ListAllByUserId(long userId) {
    return await context.JobPostScores.Where(x => x.UserId == userId).ToListAsync();
  }

  public async Task Add(JobPostScore jobPostScore) {
    await context.JobPostScores.AddAsync(jobPostScore);
  }

  public async Task<JobPostScore?> FindById(long id) {
    return await context.JobPostScores.FindAsync(id);
  }

  public void Update(JobPostScore jobPostScore) {
    context.JobPostScores.Update(jobPostScore);
  }

  public void Remove(JobPostScore jobPostScore) {
    context.JobPostScores.Remove(jobPostScore);
  }
}
