using BloodBank.Core.Entities;

namespace BloodBank.Application.Models;

public class EnderecoViewModel
{
    public int Id { get; set; }
    public string Logradouro { get; set; }
    public string Cidade { get; set; }
    public string Estado { get; set; }
    public string CEP { get; set; }
    public Doador Doador { get; set; }
}