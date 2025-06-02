namespace BloodBank.Core.Entities;

public class Endereco : BaseEntity
{
    public int Id { get; set; }
    public string Logradouro { get; set; }
    public string Cidade { get; set; }
    public string Estado { get; set; }
    public string CEP { get; set; }
    public Doador Doador { get; set; }
}