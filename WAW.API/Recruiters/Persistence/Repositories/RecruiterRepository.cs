using Microsoft.EntityFrameworkCore;
using WAW.API.Recruiters.Domain.Models;
using WAW.API.Recruiters.Domain.Repositories;
using WAW.API.Shared.Persistence.Contexts;
using WAW.API.Shared.Persistence.Repositories;

namespace WAW.API.Recruiters.Persistence.Repositories;

public class RecruiterRepository :BaseRepository,IRecruiterRepository{
  public RecruiterRepository(AppDbContext context) : base(context) { }

  public async Task<IEnumerable<Recruiter>> ListAll() {
    return await context.Recruiters.ToListAsync();
  }

  public async Task Add(Recruiter recruiter) {
    await context.Recruiters.AddAsync(recruiter);
  }

  public async Task<Recruiter?> FindById(long id) {
    return await context.Recruiters.FindAsync(id);
  }

  public void Update(Recruiter recruiter) {
    context.Recruiters.Update(recruiter);
  }

  public void Remove(Recruiter recruiter) {
    context.Recruiters.Remove(recruiter);
  }
}
