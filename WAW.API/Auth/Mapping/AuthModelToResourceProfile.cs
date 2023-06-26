using AutoMapper;
using WAW.API.Auth.Domain.Models;
using WAW.API.Auth.Resources;
using WAW.API.Cvs.Domain.Models;
using WAW.API.Cvs.Resources;
using WAW.API.Shared.Domain.Model;
using WAW.API.Shared.Persistence.Repositories;
using WAW.API.Shared.Resources;

namespace WAW.API.Auth.Mapping;

public static class AuthModelToResourceProfile {
  public static void Register(IProfileExpression profile) {
    profile.CreateMap<User, UserResource>();
    profile.CreateMap<User, AuthResource>();
    profile.CreateMap<ExternalImage, ExternalImageResource>();
    profile.CreateMap<UserEducation, UserEducationResource>();
    profile.CreateMap<UserExperience, UserExperienceResource>();
    profile.CreateMap<UserProject, UserProjectResource>();
    profile.CreateMap<Ubigeo, UbigeoResource>();
    profile.CreateMap<Cv, CvResource>();
  }
}
