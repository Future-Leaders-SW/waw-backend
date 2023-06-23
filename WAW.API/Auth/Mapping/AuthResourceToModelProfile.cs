using AutoMapper;
using WAW.API.Auth.Domain.Models;
using WAW.API.Auth.Resources;
using WAW.API.Shared.Domain.Model;
using WAW.API.Shared.Resources;

namespace WAW.API.Auth.Mapping;

public static class AuthResourceToModelProfile {
  public static void Register(IProfileExpression profile) {
    profile.CreateMap<UserCreateRequest, User>();
    profile.CreateMap<UserUpdateRequest, User>();
    profile.CreateMap<ExternalImageRequest, ExternalImage>();
    profile.CreateMap<UserEducationRequest, UserEducation>();
    profile.CreateMap<UserExperienceRequest, UserExperience>();
    profile.CreateMap<UserProjectRequest, UserProject>();
    profile.CreateMap<UbigeoRequest, Ubigeo>();
  }
}
