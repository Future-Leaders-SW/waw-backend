using AutoMapper;
using WAW.API.Auth.Resources;
using WAW.API.Subscriptions.Domain.Models;
using WAW.API.Subscriptions.Resources;

namespace WAW.API.Subscriptions.Mapping;

public static class PlanSubscriptionModelToResourceProfile {

  public static void Register(IProfileExpression profile) {
    profile.CreateMap<PlanSubscription, PlanSubscriptionResource>();

  }

}
