namespace BloodBank.Core.Entities;

public class EstoqueSangue : BaseEntity
{
    public int Id { get; set; }
    public string TipoSanguineo { get; set; }
    public string FatorRh { get; set; }
    public int QuantidadeML { get; set; }
}