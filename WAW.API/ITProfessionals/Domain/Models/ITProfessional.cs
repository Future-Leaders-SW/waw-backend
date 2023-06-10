using WAW.API.Cvs.Domain.Models;
using WAW.API.Migrations;
using WAW.API.Shared.Domain.Model;

namespace WAW.API.ITProfessionals.Domain.Models;

public class ITProfessional :BaseModel{

  public User User { get; set; }

  public long UserId{ get; set; }

  //Todo remover relacion de CV con User y pasar a ITProfessional
  public Cv Cv { get; set; }

  public long CvId { get; set; }

}
