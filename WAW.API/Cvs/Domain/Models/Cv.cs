using WAW.API.Auth.Domain.Models;
using WAW.API.Shared.Domain.Model;

namespace WAW.API.Cvs.Domain.Models;

public class Cv : BaseModel {
  public string Title { get; set; } = string.Empty;
  public byte[]? Data { get; set; }
  public long UserId { get; set; }
  public User? User { get; set; }
}