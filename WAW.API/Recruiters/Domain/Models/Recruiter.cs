using WAW.API.Auth.Domain.Models;
using WAW.API.Companies.Domain.Models;
using WAW.API.Shared.Domain.Model;

namespace WAW.API.Recruiters.Domain.Models;

public class Recruiter : BaseModel {
  public User User { get; set; } = null!;
  public long UserId { get; set; }
  public Company Company { get; set; } = null!;
  public long CompanyId { get; set; }
}
