
using WAW.API.Auth.Domain.Models;
using WAW.API.Cvs.Domain.Models;
using WAW.API.Shared.Domain.Model;

namespace WAW.API.ItProfessionals.Domain.Models;

public class ItProfessional :BaseModel {

  public User User { get; set; } = null!;

  public long UserId{ get; set; }

  //Todo remover relacion de CV con User y pasar a ItProfessional
  public Cv Cv { get; set; } = null!;

  public long CvId { get; set; }

}
