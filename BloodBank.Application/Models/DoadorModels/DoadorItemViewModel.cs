using BloodBank.Core.Entities;

namespace BloodBank.Application.Models.DoadorModels;

public class DoadorItemViewModel
{
    public DoadorItemViewModel(int id,string nomeCompleto, string email, DateTime dataNascimento)
    {
        Id = id;
        NomeCompleto = nomeCompleto;
        Email = email;
        DataNascimento = dataNascimento;
    }

    public int Id { get; set; }
    public string NomeCompleto { get; set; }
    public string Email { get; set; }
    public DateTime DataNascimento { get; set; }

    public static DoadorItemViewModel FromEntity(Doador doador)
        => new DoadorItemViewModel(doador.Id, doador.NomeCompleto, doador.Email, doador.DataNascimento);
}

