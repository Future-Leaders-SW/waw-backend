using Microsoft.EntityFrameworkCore;
using WAW.API.Auth.Domain.Models;
using WAW.API.Auth.Domain.Repositories;
using WAW.API.Shared.Persistence.Contexts;
using WAW.API.Shared.Persistence.Repositories;

namespace WAW.API.Auth.Persistence.Repositories;

public class UserRepository : BaseRepository, IUserRepository {
  public UserRepository(AppDbContext context) : base(context) {}

  public async Task<IEnumerable<User>> ListAll() {
    return await context.Users.ToListAsync();
  }

  public async Task Add(User user) {
    await context.Users.AddAsync(user);
  }

  public async Task<User?> FindById(long id) {
    return await context.Users.Where(u => u.Id == id)
      .FirstOrDefaultAsync();
  }

  public async Task<User?> FindByEmail(string email) {
    return await context.Users.Where(u => u.Email == email)
      .FirstOrDefaultAsync();
  }

  public bool ExistsByEmail(string email) {
    return context.Users.Any(x => x.Email == email);
  }

  public void Update(User user) {
    context.Users.Update(user);
  }
}
