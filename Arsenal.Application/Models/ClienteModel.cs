namespace Arsenal.Application.Models
{
  public class ClienteModel
  {
    public int Id { get; set; }
    public string NomeCompleto { get; set; }
    public string Email { get; set; }
    public bool Negativado { get; set; }
    public string Motivo { get; set; }
    public string Acao { get; set; }
  }
}