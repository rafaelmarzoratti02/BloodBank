using BloodBank.Core.Entities;

namespace BloodBank.Application.Models.EstoqueSangueModels;

public class EstoqueSangueViewModel
{
    public EstoqueSangueViewModel(int id, string tipoSanguineo, string fatorRh, int quantidadeMl)
    {
        Id = id;
        TipoSanguineo = tipoSanguineo;
        FatorRh = fatorRh;
        QuantidadeML = quantidadeMl;
    }

    public int Id { get; set; }
    public string TipoSanguineo { get; set; }
    public string FatorRh { get; set; }
    public int QuantidadeML { get; set; }
    
    public static EstoqueSangueViewModel FromEntity(EstoqueSangue estoqueSangue)
        => new EstoqueSangueViewModel(estoqueSangue.Id, estoqueSangue.TipoSanguineo, estoqueSangue.FatorRh, estoqueSangue.QuantidadeML);
}