using WAW.API.Companies.Domain.Models;
using WAW.API.Shared.Domain.Service.Communication;

namespace WAW.API.Companies.Domain.Services.Communication;

public class CompanyResponse : BaseResponse<Company> {
  public CompanyResponse(string message) : base(message) {}
  public CompanyResponse(Company resource) : base(resource) {}
}
