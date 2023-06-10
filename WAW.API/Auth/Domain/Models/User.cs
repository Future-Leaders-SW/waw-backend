using System.Text.Json.Serialization;
using WAW.API.Shared.Domain.Model;
using WAW.API.Subscriptions.Domain.Models;
using WAW.API.Cvs.Domain.Models;

namespace WAW.API.Auth.Domain.Models;

public class User : BaseModel {
  public string FullName { get; set; } = string.Empty;
  public string Email { get; set; } = string.Empty;

  [JsonIgnore]
  public string Password { get; set; } = string.Empty;

  public DateTime Birthdate { get; set; }

  public string? About { get; set; }
  //Todo Corregir picture

  public long? PictureId { get; set; }

  public string address { get; set; }
  public string PreferredName { get; set; } = string.Empty;

  public string? Location { get; set; }

  public int ProfileViews { get; set; }

  public string? Biography { get; set; }


  // Relationships
  public long? CoverId { get; set; }
  public IList<PlanSubscription> PlanSubscriptions { get; set; }


  // Include CV
  //TODO pasar a ItProfessional
  public long? CvId { get; set; }
  public Cv Cv { get; set; }

  public long? UbigeoId { get; set; }
  public Ubigeo Ubigeo{ get; set; }

}
