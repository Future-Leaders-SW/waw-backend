using AutoMapper;
using WAW.API.Auth.Mapping;
using WAW.API.Chat.Mapping;
using WAW.API.Cvs.Mapping;
using WAW.API.Employers.Mapping;
using WAW.API.Job.Mapping;

namespace WAW.API.Shared.Mapping;

public class ResourceToModelProfile : Profile {
  public ResourceToModelProfile() {
    AuthResourceToModelProfile.Register(this);
    CompanyResourceToModelProfile.Register(this);
    JobResourceToModelProfile.Register(this);
    ChatResourceToModelProfile.Register(this);
    CvResourceToModelProfile.Register(this);
    CvCreateModelToModelProfile.Register(this);
  }
}
