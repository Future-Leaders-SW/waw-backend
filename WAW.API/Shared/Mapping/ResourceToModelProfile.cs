using AutoMapper;
using WAW.API.Auth.Mapping;
using WAW.API.Chat.Mapping;
using WAW.API.Companies.Mapping;
using WAW.API.Cvs.Mapping;
using WAW.API.Job.Mapping;
using WAW.API.JobPostScores.Mapping;
using WAW.API.Subscriptions.Mapping;
namespace WAW.API.Shared.Mapping;

public class ResourceToModelProfile : Profile {
  public ResourceToModelProfile() {
    AuthResourceToModelProfile.Register(this);
    CompanyResourceToModelProfile.Register(this);
    JobResourceToModelProfile.Register(this);
    ChatResourceToModelProfile.Register(this);
    SubscriptionResourceToModelProfile.Register(this);
    PlanSubscriptionResourceToModelProfile.Register(this);
    CvResourceToModelProfile.Register(this);
    CvCreateModelToModelProfile.Register(this);
    UbigeoResourceToModel.Register(this);
    JobPostScoreResourceToModel.Register(this);
  }
}
