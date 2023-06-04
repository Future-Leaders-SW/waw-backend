using AutoMapper;
using WAW.API.Auth.Mapping;
using WAW.API.Chat.Mapping;
using WAW.API.Employers.Mapping;
using WAW.API.Job.Mapping;
using WAW.API.Subscriptions.Mapping;
namespace WAW.API.Shared.Mapping;

public class ModelToResourceProfile : Profile {
  public ModelToResourceProfile() {
    AuthModelToResourceProfile.Register(this);
    CompanyModelToResourceProfile.Register(this);
    JobModelToResourceProfile.Register(this);
    ChatModelToResourceProfile.Register(this);
    SubscriptionModelToResourceProfile.Register(this);
    PlanSubscriptionModelToResourceProfile.Register(this);
  }
}
