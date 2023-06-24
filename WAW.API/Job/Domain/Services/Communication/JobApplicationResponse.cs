using WAW.API.Job.Domain.Models;
using WAW.API.Shared.Domain.Service.Communication;

namespace WAW.API.Job.Domain.Services.Communication;

public class JobApplicationResponse : BaseResponse<JobApplication> {
  public JobApplicationResponse(string message) : base(message) { }

  public JobApplicationResponse(JobApplication resource) : base(resource) { }


}
