using AutoMapper;
using WAW.API.Subscriptions.Domain.Models;
using WAW.API.Subscriptions.Resources;

namespace WAW.API.Subscriptions.Mapping;

public class SubscriptionResourceToModelProfile {

  public static void Register(IProfileExpression profile) {
    profile.CreateMap<SubscriptionRequest, Subscription>();
  }
}
