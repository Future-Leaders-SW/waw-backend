using Microsoft.EntityFrameworkCore;
using WAW.API.Cvs.Domain.Models;
using WAW.API.Cvs.Domain.Repositories;
using WAW.API.Shared.Persistence.Contexts;
using WAW.API.Shared.Persistence.Repositories;

namespace WAW.API.Cvs.Persistence.Repositories;

public class CvRepository : BaseRepository, ICvRepository {
  public CvRepository(AppDbContext context) : base(context) {}

  public async Task<IEnumerable<Cv>> ListAll() {
    return await context.Cvs.ToListAsync();
  }
  public async Task Add(Cv cv) {
    await context.Cvs.AddAsync(cv);
  }

  public async Task<Cv?> FindById(long id) {
    return await context.Cvs.FindAsync(id);
  }

  public void Update(Cv cv) {
    context.Cvs.Update(cv);
  }

  public void Remove(Cv cv) {
    context.Cvs.Remove(cv);
  }
}
