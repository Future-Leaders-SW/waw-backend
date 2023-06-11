namespace WAW.API.Auth.Domain.Models;

using System.ComponentModel;

public enum UserType {
  [Description("ITProfessional")]
  ITProfessional,

  [Description("Recruiter")]
  Recruiter,
  [Description("Admin")]
  Admin
}
