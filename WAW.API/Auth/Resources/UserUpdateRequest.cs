using System.ComponentModel.DataAnnotations;
using Swashbuckle.AspNetCore.Annotations;
using WAW.API.Cvs.Resources;
using WAW.API.Shared.Resources;

namespace WAW.API.Auth.Resources;

public class UserUpdateRequest {
  [SwaggerSchema("User fullname", Nullable = false)]
  [Required]
  public string? FullName { get; set; }

  [SwaggerSchema("User preferred name to use in the app", Nullable = false)]
  [Required]
  public string? PreferredName { get; set; }

  [SwaggerSchema("User location", Nullable = true)]
  public string? Location { get; set; }

  [SwaggerSchema("User biography", Nullable = true)]
  public string? Biography { get; set; }

  [SwaggerSchema("User abstract", Nullable = true)]
  public string? About { get; set; }

  [SwaggerSchema("User birthdate", Nullable = false)]
  [Required]
  public DateTime? Birthdate { get; set; }

  [SwaggerSchema("User cover picture", Nullable = true)]
  public ExternalImageRequest? Cover { get; set; }

  [SwaggerSchema("User profile picture", Nullable = true)]
  public ExternalImageRequest? Picture { get; set; }

  [SwaggerSchema("User Ubigeo", Nullable = false)]
  public UbigeoRequest? Ubigeo { get; set; }
  
  [SwaggerSchema("User cv", Nullable = false)]
  public CvRequest? Cv { get; set; }
}
