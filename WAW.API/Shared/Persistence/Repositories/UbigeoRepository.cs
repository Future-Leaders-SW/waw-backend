using Microsoft.EntityFrameworkCore;
using WAW.API.Shared.Domain.Model;
using WAW.API.Shared.Domain.Repositories;
using WAW.API.Shared.Persistence.Contexts;

namespace WAW.API.Shared.Persistence.Repositories;

public class UbigeoRepository :BaseRepository, IUbigeoRepository{

  public UbigeoRepository(AppDbContext context) : base(context) {}

  public async Task<IEnumerable<Ubigeo>> ListAll() {
    return await context.Ubigeo.ToListAsync();
  }

  public async Task Add(Ubigeo ubigeo) {
    await context.Ubigeo.AddAsync(ubigeo);
  }

  public async Task<Ubigeo?> FindById(long id) {
    return await context.Ubigeo.FindAsync(id);
  }

  public void Update(Ubigeo ubigeo) {
    context.Ubigeo.Update(ubigeo);
  }

  public void Remove(Ubigeo ubigeo) {
    context.Ubigeo.Remove(ubigeo);
  }
}
