using AutoMapper;
using WAW.API.Subscriptions.Resources;

namespace WAW.API.Subscriptions.Mapping;

public class SubscriptionModelToResourceProfile {

  public static void Register(IProfileExpression profile) {
    profile.CreateMap<SubscriptionModelToResourceProfile, SubscriptionResource>();
  }

}
