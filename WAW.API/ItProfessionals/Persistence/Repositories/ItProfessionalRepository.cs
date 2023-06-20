using Microsoft.EntityFrameworkCore;
using WAW.API.ItProfessionals.Domain.Models;
using WAW.API.ItProfessionals.Domain.Repositories;
using WAW.API.Shared.Persistence.Contexts;
using WAW.API.Shared.Persistence.Repositories;

namespace WAW.API.ItProfessionals.Persistence.Repositories;

public class ItProfessionalRepository :BaseRepository,IItProfessionalRepository{
  public ItProfessionalRepository(AppDbContext context) : base(context) {}

  public async Task<IEnumerable<ItProfessional>> ListAll() {
    return await context.ItProfessionals.ToListAsync();
  }

  public async Task Add(ItProfessional itProfessional) {
    await context.ItProfessionals.AddAsync(itProfessional);
  }

  public async Task<ItProfessional?> FindById(long id) {
    return await context.ItProfessionals.FindAsync(id);
  }

  public void Update(ItProfessional itProfessional) {
    context.ItProfessionals.Update(itProfessional);
  }

  public void Remove(ItProfessional itProfessional) {
    context.ItProfessionals.Remove(itProfessional);
  }
}
