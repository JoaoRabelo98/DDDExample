namespace Arsenal.Domain.Enitities.Cliente
{
  public class ClienteEntity : BaseEntity
  {
    public string PrimeiroNome { get; set; }
    public string UltimoNome { get; set; }
    public string Email { get; set; }
    public bool Negativado { get; set; }
    public int MotivoId { get; set; }
    public string Motivo { get; set; }
    public string Acao { get; set; }
  }
}