namespace BloodBank.Core.Entities;

public class Doador : BaseEntity
{
    public string NomeCompleto { get; set; }
    public string Email { get; set; }
    public DateTime DataNascimento { get; set; }
    public string Genero { get; set; }
    public double Peso { get; set; }
    public string TipoSanguineo { get; set; }
    public string FatorRH { get; set; }
    public int EnderecoId { get; set; }
    public List<Doacao> Doacoes { get; set; }
    public Endereco Endereco { get; set; }
}