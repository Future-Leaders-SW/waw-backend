using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using Swashbuckle.AspNetCore.Annotations;
namespace WAW.API.Cvs.Resources; 

public class CvCreateModel {
  [SwaggerSchema("Title of the CV", Nullable = false)]
  [Required]
  public string Title { get; set; }
        
  [SwaggerSchema("User ID associated with the CV", Nullable = false)]
  [Required]
  public long UserId { get; set; }

  [SwaggerSchema("CV file", Nullable = false)]
  [Required]
  public IFormFile Data { get; set; }
}
