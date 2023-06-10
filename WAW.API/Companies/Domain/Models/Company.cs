using WAW.API.Shared.Domain.Model;

namespace WAW.API.Companies.Domain.Models;

public class Company : BaseModel {
  public string Name { get; set; } = string.Empty;
}
