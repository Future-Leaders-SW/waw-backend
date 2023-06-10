using Microsoft.EntityFrameworkCore;
using WAW.API.ITProfessionals.Domain.Models;
using WAW.API.ITProfessionals.Domain.Repositories;
using WAW.API.Shared.Persistence.Contexts;
using WAW.API.Shared.Persistence.Repositories;

namespace WAW.API.ITProfessionals.Persistence.Repositories;

public class ITProfessionalRepository :BaseRepository,IITProfessionalRepository{
  public ITProfessionalRepository(AppDbContext context) : base(context) {}

  public async Task<IEnumerable<ITProfessional>> ListAll() {
    return await context.ITPRofessionals.ToListAsync();
  }

  public async Task Add(ITProfessional itProfessional) {
    await context.ITPRofessionals.AddAsync(itProfessional);
  }

  public async Task<ITProfessional?> FindById(long id) {
    return await context.ITPRofessionals.FindAsync(id);
  }

  public void Update(ITProfessional itProfessional) {
    context.ITPRofessionals.Update(itProfessional);
  }

  public void Remove(ITProfessional itProfessional) {
    context.ITPRofessionals.Remove(itProfessional);
  }
}
