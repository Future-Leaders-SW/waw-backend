using System.ComponentModel;
using Swashbuckle.AspNetCore.Annotations;
using WAW.API.Auth.Resources;

namespace WAW.API.Job.Resources;

public class JobApplicationResource {
  [SwaggerSchema("The ID of the job application.", ReadOnly = true)]
  public long Id { get; set; }

  [SwaggerSchema("The user associated with the job application.", Nullable = false)]
  public UserResource? User { get; set; }

  [SwaggerSchema("The offer to which the job application is made.", Nullable = false)]
  public OfferResource? Offer { get; set; }

  [SwaggerSchema("The date of the job application.", Nullable = false)]
  public DateTime ApplicationDate { get; set; }

}
