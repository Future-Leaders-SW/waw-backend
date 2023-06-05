using AutoMapper;
using WAW.API.Subscriptions.Domain.Models;
using WAW.API.Subscriptions.Resources;

namespace WAW.API.Subscriptions.Mapping;

public class SubscriptionModelToResourceProfile {

  public static void Register(IProfileExpression profile) {
    profile.CreateMap<Subscription, SubscriptionResource>();
  }

}
