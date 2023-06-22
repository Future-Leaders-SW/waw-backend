namespace WAW.API.Shared.Domain.Model;

public class Ubigeo : BaseModel{
  public string Departamento { get; set; } = string.Empty;
  public string Provincia { get; set; } = string.Empty;
  public string Distrito { get; set; } = string.Empty;

}
