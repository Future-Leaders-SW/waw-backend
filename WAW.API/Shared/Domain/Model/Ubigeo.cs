namespace WAW.API.Shared.Domain.Model;

public class Ubigeo : BaseModel{
  public string Departamento { get; set; } = String.Empty;
  public string Provincia { get; set; } = String.Empty;
  public string Distrito { get; set; } = String.Empty;

}
