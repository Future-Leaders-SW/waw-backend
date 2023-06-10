namespace WAW.API.Auth.Domain.Models;

using System.ComponentModel;

public enum UserType {
  [Description("Professional")]
  Professional,

  [Description("Recruiter")]
  Recruiter,
  [Description("Admin")]
  Admin
}
