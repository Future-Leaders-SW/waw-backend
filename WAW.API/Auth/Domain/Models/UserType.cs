using System.ComponentModel;

namespace WAW.API.Auth.Domain.Models;

public enum UserType {
  [Description("ITProfessional")]
  ITProfessional,

  [Description("Recruiter")]
  Recruiter,

  [Description("Admin")]
  Admin
}
