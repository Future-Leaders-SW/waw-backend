using System.ComponentModel.DataAnnotations;
using Swashbuckle.AspNetCore.Annotations; 

namespace WAW.API.Job.Resources;

public class JobApplicationRequest {

  [Required]
  [SwaggerSchema("The ID of the user associated with the job application.", Nullable = true)]
  public long? UserId { get; set; }

  [Required]
  [SwaggerSchema("The ID of the offer to which the job application is being made.", Nullable = true)]
  public long? OfferId { get; set; }

  [Required]
  [DataType(DataType.DateTime)]
  [SwaggerSchema("The date of the job application.", Nullable = false)]
  public DateTime ApplicationDate { get; set; }


}
